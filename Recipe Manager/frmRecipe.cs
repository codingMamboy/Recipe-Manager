using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmRecipe : Form
    {
        // Connection string to the MySQL database
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private readonly int userId;                      // ID of the logged-in user
        private string uploadedImagePath = string.Empty;  // Local path of any uploaded image

        // Standard constructor, stores user ID
        public frmRecipe(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // Overloaded constructor for when a recipe is imported
        public frmRecipe(int userId, frmImportPage.Recipe importedRecipe)
            : this(userId)
        {
            InitializeImportedRecipe(importedRecipe);
        }

        // Populate form fields from an imported recipe object
        private void InitializeImportedRecipe(frmImportPage.Recipe importedRecipe)
        {
            txtDishname.Text = importedRecipe.Name;
            txtDirection.Text = importedRecipe.Instructions;

            // Add each imported ingredient to the checklist
            if (!string.IsNullOrEmpty(importedRecipe.Ingredients))
            {
                foreach (var ing in importedRecipe.Ingredients.Split(','))
                {
                    lstIngredients.Items.Add(ing.Trim(), true);
                }
            }

            // Download and display the imported recipe image
            if (!string.IsNullOrEmpty(importedRecipe.ImageUrl))
                LoadImageFromUrl(importedRecipe.ImageUrl);
        }

        // Downloads an image from a URL into the local Images folder
        private void LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    string imagesDir = Path.Combine(Application.StartupPath, "Images");
                    Directory.CreateDirectory(imagesDir);

                    string fileName = Path.GetFileName(new Uri(imageUrl).LocalPath);
                    string localPath = Path.Combine(imagesDir, fileName);
                    client.DownloadFile(imageUrl, localPath);

                    uploadedImagePath = Path.Combine("Images", fileName);
                    pictureBoxRecipe.Image = Image.FromFile(localPath);
                }
            }
            catch
            {
                MessageBox.Show(
                    "Failed to load image from URL.",
                    "Image Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Form Load event: configure UI and asynchronously load initial data
        private void frmRecipe_Load(object sender, EventArgs e)
        {
            // Enable multiline and line breaks in the directions textbox
            txtDirection.Multiline = true;
            txtDirection.AcceptsReturn = true;

            // Run database loads on a background thread to keep UI responsive
            Task.Run(() =>
            {
                LoadUser();
                LoadCourses();
            });
        }

        // Helper to run arbitrary SQL and process results
        private void LoadData(
            string sql,
            Action<MySqlCommand> paramSetter,
            Action<MySqlDataReader> readerAction)
        {
            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        // Set parameters if provided
                        paramSetter?.Invoke(cmd);
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Process each row via the provided action
                            readerAction?.Invoke(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error: {ex.Message}\n{ex.StackTrace}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Load and display the current user's username
        private void LoadUser()
        {
            LoadData(
                "SELECT username FROM users WHERE user_id = @id",
                cmd => cmd.Parameters.AddWithValue("@id", userId),
                reader =>
                {
                    if (reader.Read())
                    {
                        // Safely update UI from background thread
                        Invoke((Action)(() =>
                            btnWelcome.Text = "Welcome, " + reader.GetString(0)
                        ));
                    }
                }
            );
        }

        // Populate the ingredients dropdown

        // Populate the course/category dropdown
        private void LoadCourses()
        {
            LoadData(
                "SELECT category_name FROM categories",
                null,
                reader =>
                {
                    Invoke((Action)(() =>
                    {
                        cboCourses.Items.Clear();
                        while (reader.Read())
                            cboCourses.Items.Add(reader.GetString(0));
                    }));
                }
            );
        }

        // Navigate back to the home form
        private void btnHome_Click(object sender, EventArgs e)
        {
            var frmHome = new frmHome(userId);
            this.Close();
            frmHome.Show();
        }

        // Add the selected ingredient entry to the checklist
        private void btnAddIngre_Click(object sender, EventArgs e)
        {
            if (!ValidateIngredientInputs()) return;

            string entry = $"{txtScale.Text.Trim()} {cboMeasurement.SelectedItem} {cboIngredients.SelectedItem}";
            if (lstIngredients.Items.Contains(entry))
            {
                MessageBox.Show("Ingredient already added.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lstIngredients.Items.Add(entry, true);
                ClearInputs();
            }
        }

        // Ensure ingredient fields are filled before adding
        private bool ValidateIngredientInputs()
        {
            if (cboIngredients.SelectedItem == null ||
                cboMeasurement.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtScale.Text))
            {
                MessageBox.Show(
                    "Complete all ingredient fields.",
                    "Incomplete Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }
            return true;
        }

        // Reset the ingredient input controls
        private void ClearInputs()
        {
            cboIngredients.SelectedIndex = -1;
            cboMeasurement.SelectedIndex = -1;
            txtScale.Clear();
        }

        // Clear all added ingredients
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstIngredients.Items.Clear();
            ClearInputs();
        }


        // Handle the “Upload Recipe” button click asynchronously
        private async void btnUploadRecipe_Click(object sender, EventArgs e)
        {
            btnUploadRecipe.Text = "Loading...";
            btnUploadRecipe.Enabled = false;

            if (!ValidateRecipeInputs())
            {
                ResetButtonState();
                return;
            }

            // Ensure a course is selected
            if (cboCourses.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a course before uploading.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                ResetButtonState();
                return;
            }

            string selectedCourse = cboCourses.SelectedItem.ToString().Trim();
            int catId;
            try
            {
                catId = GetCategoryId(selectedCourse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error retrieving category ID: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                ResetButtonState();
                return;
            }

            if (catId == 0)
            {
                MessageBox.Show(
                    "Selected course not found in database.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                ResetButtonState();
                return;
            }

            // Compile ingredient list as a comma-separated string
            string ingredients = string.Join(", ", lstIngredients.Items.Cast<string>());

            // Run the database insert on a background thread
            await Task.Run(() =>
            {
                LoadData(
                    @"INSERT INTO recipes
                      (user_id, recipe_name, category_id, ingredients, instructions, image_path)
                      VALUES (@u,@n,@c,@i,@s,@p)",
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@u", userId);
                        cmd.Parameters.AddWithValue("@n", txtDishname.Text.Trim());
                        cmd.Parameters.AddWithValue("@c", catId);
                        cmd.Parameters.AddWithValue("@i", ingredients);
                        cmd.Parameters.AddWithValue("@s", txtDirection.Text.Trim());
                        cmd.Parameters.AddWithValue(
                            "@p",
                            string.IsNullOrEmpty(uploadedImagePath)
                                ? (object)DBNull.Value
                                : uploadedImagePath
                        );
                    },
                    null
                );
            });

            // Notify success, reset form and button
            MessageBox.Show("Recipe saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
            ResetButtonState();
        }

        // Restore Upload button text and enabled state
        private void ResetButtonState()
        {
            btnUploadRecipe.Text = "Upload Recipe";
            btnUploadRecipe.Enabled = true;
        }

        // Ensure all recipe fields are valid before uploading
        private bool ValidateRecipeInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDishname.Text))
                return ShowWarning("Dish name is required.");
            if (string.IsNullOrWhiteSpace(txtDirection.Text))
                return ShowWarning("Directions are required.");
            if (lstIngredients.Items.Count == 0)
                return ShowWarning("Add at least one ingredient.");
            if (cboCourses.SelectedItem == null)
                return ShowWarning("Select a course.");

            return true;

            bool ShowWarning(string msg)
            {
                MessageBox.Show(msg, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        // Clear all form fields back to their default state
        private void ResetForm()
        {
            Invoke((Action)(() =>
            {
                txtDishname.Clear();
                txtDirection.Clear();
                lstIngredients.Items.Clear();
                pictureBoxRecipe.Image = null;
                ClearInputs();
                cboCourses.SelectedIndex = -1;
            }));
        }

        // Retrieve numeric category ID for a given category name
        private int GetCategoryId(string name)
        {
            int id = 0;
            LoadData(
                "SELECT category_id FROM categories WHERE category_name = @n",
                cmd => cmd.Parameters.AddWithValue("@n", name),
                reader => { if (reader.Read()) id = reader.GetInt32(0); }
            );
            return id;
        }

        // Open the “Import Recipe” dialog, then return here afterward
        private void btnImportUrl_Click(object sender, EventArgs e)
        {
            Hide();
            new frmImportPage(userId).ShowDialog();
            Show();
        }

        // Restrict Scale textbox input to digits and at most one decimal point
        private void txtScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool invalidChar = !char.IsControl(e.KeyChar)
                               && !char.IsDigit(e.KeyChar)
                               && e.KeyChar != '.';
            bool secondDot = e.KeyChar == '.'
                             && txtScale.Text.Contains('.');
            e.Handled = invalidChar || secondDot;
        }

        // Validate Scale value is a float between 0.01 and 100
        private void txtScale_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScale.Text)) return;

            if (!float.TryParse(txtScale.Text, out float v) || v < 0.01f || v > 100f)
            {
                MessageBox.Show(
                    "Enter a value between 0.01 and 100.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                e.Cancel = true;
            }
        }

        // Exit the entire application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            var frmProfile = new frmProfile(userId);
            this.Close();
            frmProfile.Show();
        }

        private void btnPlanner_Click(object sender, EventArgs e)
        {
            var frmPlanner = new frmPlanner(userId);
            this.Close();
            frmPlanner.Show();
        }

        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                var fileInfo = new FileInfo(ofd.FileName);
                // Enforce a 2MB size limit
                if (fileInfo.Length > 2 * 1024 * 1024)
                {
                    MessageBox.Show(
                        "Select an image under 2MB.",
                        "File Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Copy into an “Images” folder inside the app directory
                string imagesDir = Path.Combine(Application.StartupPath, "Images");
                Directory.CreateDirectory(imagesDir);

                string destPath = Path.Combine(imagesDir, fileInfo.Name);
                File.Copy(ofd.FileName, destPath, true);

                uploadedImagePath = Path.Combine("Images", fileInfo.Name);
                pictureBoxRecipe.Image = Image.FromFile(destPath);
            }
        }
    }
}
