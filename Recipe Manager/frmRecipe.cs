// Required namespaces for various .NET functionalities
using System;
using System.ComponentModel;     // For CancelEventArgs
using System.Drawing;           // For image handling
using System.IO;                // For file and directory operations
using System.Linq;              // For working with collections
using System.Threading.Tasks;   // For asynchronous operations
using System.Windows.Forms;     // For Windows Forms UI
using MySql.Data.MySqlClient;   // For MySQL database access

namespace Recipe_Manager
{
    public partial class frmRecipe : Form
    {
        // Connection string to connect to MySQL database
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        private readonly int userId; // Stores the ID of the currently logged-in user
        private string uploadedImagePath = string.Empty; // Path to uploaded image

        // Constructor used when recipe is not being imported
        public frmRecipe(int userId)
        {
            InitializeComponent(); // Initializes form components
            this.userId = userId;  // Set user ID for session
        }

        // Overloaded constructor when importing a recipe from another form
        public frmRecipe(int userId, frmImportPage.Recipe importedRecipe)
            : this(userId) // Call the base constructor
        {
            InitializeImportedRecipe(importedRecipe); // Load the imported recipe into UI
        }

        // Load imported recipe into the form fields
        private void InitializeImportedRecipe(frmImportPage.Recipe importedRecipe)
        {
            txtDishname.Text = importedRecipe.Name;
            txtDirection.Text = importedRecipe.Instructions;

            // If ingredients are provided, split and add to checked list box
            if (!string.IsNullOrEmpty(importedRecipe.Ingredients))
            {
                foreach (var ing in importedRecipe.Ingredients.Split(','))
                {
                    lstIngredients.Items.Add(ing.Trim(), true); // Checked by default
                }
            }

            // Load the image from URL, if provided
            if (!string.IsNullOrEmpty(importedRecipe.ImageUrl))
                LoadImageFromUrl(importedRecipe.ImageUrl);
        }

        // Download image from URL and save it locally in Images folder
        private void LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    string imagesDir = Path.Combine(Application.StartupPath, "Images");
                    Directory.CreateDirectory(imagesDir); // Ensure folder exists

                    string fileName = Path.GetFileName(new Uri(imageUrl).LocalPath); // Extract file name from URL
                    string localPath = Path.Combine(imagesDir, fileName); // Local save path

                    client.DownloadFile(imageUrl, localPath); // Download the image

                    uploadedImagePath = Path.Combine("Images", fileName); // Store relative path
                    pictureBoxRecipe.Image = Image.FromFile(localPath); // Display in PictureBox
                }
            }
            catch
            {
                MessageBox.Show("Failed to load image from URL.", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // When form loads, configure UI and fetch data
        private void frmRecipe_Load(object sender, EventArgs e)
        {
            txtDirection.Multiline = true;
            txtDirection.AcceptsReturn = true;

            // Load user info and course list in background thread
            Task.Run(() =>
            {
                LoadUser();
                LoadCourses();
            });
        }

        // General-purpose method to execute SQL commands and process results
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
                        paramSetter?.Invoke(cmd); // Set parameters if needed
                        using (var reader = cmd.ExecuteReader())
                        {
                            readerAction?.Invoke(reader); // Process result
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load the current user's name to welcome them
        private void LoadUser()
        {
            LoadData(
                "SELECT username FROM users WHERE user_id = @id",
                cmd => cmd.Parameters.AddWithValue("@id", userId),
                reader =>
                {
                    if (reader.Read())
                    {
                        Invoke((Action)(() =>
                            btnWelcome.Text = "Welcome, " + reader.GetString(0)
                        ));
                    }
                }
            );
        }

        // Load recipe categories into the combo box
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

        // Navigate to Home form
        private void btnHome_Click(object sender, EventArgs e)
        {
            var frmHome = new frmHome(userId);
            this.Close();
            frmHome.Show();
        }

        // Add an ingredient to the ingredient list
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
                lstIngredients.Items.Add(entry, true); // Add and check it
                ClearInputs(); // Reset input fields
            }
        }

        // Check if ingredient fields are filled
        private bool ValidateIngredientInputs()
        {
            if (cboIngredients.SelectedItem == null ||
                cboMeasurement.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtScale.Text))
            {
                MessageBox.Show("Complete all ingredient fields.", "Incomplete Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Clear ingredient input fields
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

        // Upload recipe to database
        private async void btnUploadRecipe_Click(object sender, EventArgs e)
        {
            btnUploadRecipe.Text = "Loading...";
            btnUploadRecipe.Enabled = false;

            if (!ValidateRecipeInputs())
            {
                ResetButtonState();
                return;
            }

            if (cboCourses.SelectedItem == null)
            {
                MessageBox.Show("Please select a course before uploading.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show($"Error retrieving category ID: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetButtonState();
                return;
            }

            if (catId == 0)
            {
                MessageBox.Show("Selected course not found in database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetButtonState();
                return;
            }

            string ingredients = string.Join(", ", lstIngredients.Items.Cast<string>());

            // Insert recipe into database on background thread
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
                        cmd.Parameters.AddWithValue("@p", string.IsNullOrEmpty(uploadedImagePath) ? (object)DBNull.Value : uploadedImagePath);
                    },
                    null
                );
            });

            MessageBox.Show("Recipe saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
            ResetButtonState();
        }

        // Restore Upload button to default state
        private void ResetButtonState()
        {
            btnUploadRecipe.Text = "Upload Recipe";
            btnUploadRecipe.Enabled = true;
        }

        // Check if all form inputs are valid
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

        // Reset form fields
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

        // Get ID of category from category name
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

        // Show Import Recipe form
        private void btnImportUrl_Click(object sender, EventArgs e)
        {
            Hide();
            new frmImportPage(userId).ShowDialog();
            Show();
        }

        // Allow only digits and one decimal point in txtScale
        private void txtScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool invalidChar = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.';
            bool secondDot = e.KeyChar == '.' && txtScale.Text.Contains('.');
            e.Handled = invalidChar || secondDot;
        }

        // Validate txtScale value
        private void txtScale_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScale.Text)) return;

            if (!float.TryParse(txtScale.Text, out float v) || v < 0.01f || v > 100f)
            {
                MessageBox.Show("Enter a value between 0.01 and 100.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        // Exit application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Navigate to Profile form
        private void btnWelcome_Click(object sender, EventArgs e)
        {
            var frmProfile = new frmProfile(userId);
            this.Close();
            frmProfile.Show();
        }

        // Navigate to Planner form
        private void btnPlanner_Click(object sender, EventArgs e)
        {
            var frmPlanner = new frmPlanner(userId);
            this.Close();
            frmPlanner.Show();
        }

        // Handle image upload via file dialog
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

                // Limit file size to 2MB
                if (fileInfo.Length > 2 * 1024 * 1024)
                {
                    MessageBox.Show("Select an image under 2MB.", "File Too Large", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
