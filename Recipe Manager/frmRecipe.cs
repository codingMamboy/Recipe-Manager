// [Same using directives and namespace declaration]
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmRecipe : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;
        private int userId;
        private string uploadedImagePath = string.Empty;

        public frmRecipe(int userId)
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            this.userId = userId;
        }

        public frmRecipe(int userId, frmImportPage.Recipe importedRecipe) : this(userId)
        {
            txtDishname.Text = importedRecipe.Name;
            txtDirection.Text = importedRecipe.Instructions;

            if (!string.IsNullOrEmpty(importedRecipe.Ingredients))
            {
                var ingredientsList = importedRecipe.Ingredients.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in ingredientsList)
                    lstIngredients.Items.Add(item.Trim(), true);
            }

            if (!string.IsNullOrEmpty(importedRecipe.ImageUrl))
            {
                try
                {
                    using (var client = new System.Net.WebClient())
                    {
                        string imagesDir = Path.Combine(Application.StartupPath, "Images");
                        if (!Directory.Exists(imagesDir))
                            Directory.CreateDirectory(imagesDir);

                        string fileName = Path.GetFileName(new Uri(importedRecipe.ImageUrl).LocalPath);
                        string localPath = Path.Combine(imagesDir, fileName);
                        client.DownloadFile(importedRecipe.ImageUrl, localPath);

                        uploadedImagePath = Path.Combine("Images", fileName);
                        pictureBoxRecipe.Image = Image.FromFile(localPath);
                    }
                }
                catch
                {
                    MessageBox.Show("Failed to load image from URL.", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmRecipe_Load_1(object sender, EventArgs e)
        {
            txtDirection.Multiline = true;
            txtDirection.AcceptsReturn = true;
            LoadIngredients();
            LoadCourses();
            LoadUser();
        }

        private void LoadUser()
        {
            try
            {
                string query = "SELECT username FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    btnWelcome.Text = "Welcome, " + reader["username"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIngredients()
        {
            try
            {
                conn.Open();
                string query = "SELECT ingredient_name FROM ingredients";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        cboIngredients.Items.Add(reader["ingredient_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ingredients: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadCourses()
        {
            try
            {
                conn.Open();
                string query = "SELECT category_name FROM categories";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        cboCourses.Items.Add(reader["category_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            var home = new frmHome(userId);
            this.Hide();
            home.Show();
        }

        private void btnAddIngre_Click(object sender, EventArgs e)
        {
            if (cboIngredients.SelectedItem != null &&
                cboMeasurement.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(txtScale.Text))
            {
                string display = $"{txtScale.Text.Trim()} {cboMeasurement.SelectedItem} {cboIngredients.SelectedItem}";

                if (!lstIngredients.Items.Contains(display))
                {
                    lstIngredients.Items.Add(display, true);
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Ingredient already added.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please fill out quantity, measurement, and ingredient.", "Incomplete Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearInputs()
        {
            cboIngredients.SelectedIndex = -1;
            cboMeasurement.SelectedIndex = -1;
            txtScale.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstIngredients.Items.Clear();
            ClearInputs();
        }

        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var info = new FileInfo(ofd.FileName);
                    if (info.Length > 2 * 1024 * 1024)
                    {
                        MessageBox.Show("The file is too large. Please select an image under 2MB.", "File Too Large", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string imagesDir = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imagesDir))
                        Directory.CreateDirectory(imagesDir);

                    string fileName = Path.GetFileName(ofd.FileName);
                    string destPath = Path.Combine(imagesDir, fileName);
                    File.Copy(ofd.FileName, destPath, true);

                    uploadedImagePath = Path.Combine("Images", fileName);

                    pictureBoxRecipe.Image?.Dispose();
                    pictureBoxRecipe.Image = Image.FromFile(destPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading image:\n" + ex.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUploadRecipe_Click(object sender, EventArgs e)
        {
            btnUploadRecipe.Text = "Loading...";
            btnUploadRecipe.Enabled = false;

            if (!ValidateRecipeInputs())
            {
                btnUploadRecipe.Text = "Upload Recipe";
                btnUploadRecipe.Enabled = true;
                return;
            }

            string recipeName = txtDishname.Text.Trim();
            string description = txtDirection.Text.Trim();
            var ingredients = lstIngredients.Items.Cast<object>().Select(i => i.ToString()).ToList();
            string selectedCourse = cboCourses.SelectedItem.ToString();

            try
            {
                conn.Open();
                int categoryId = GetCategoryId(selectedCourse);
                if (categoryId == 0) return;

                string sql = @"INSERT INTO recipes (user_id, recipe_name, category_id, ingredients, instructions, image_path) 
                               VALUES (@user_id, @recipe_name, @category_id, @ingredients, @instructions, @image_path)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@recipe_name", recipeName);
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    cmd.Parameters.AddWithValue("@ingredients", string.Join(", ", ingredients));
                    cmd.Parameters.AddWithValue("@instructions", description);
                    cmd.Parameters.AddWithValue("@image_path", string.IsNullOrEmpty(uploadedImagePath) ? (object)DBNull.Value : uploadedImagePath);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Recipe saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save recipe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                btnUploadRecipe.Text = "Upload Recipe";
                btnUploadRecipe.Enabled = true;
            }
        }

        private bool ValidateRecipeInputs()
        {
            if (string.IsNullOrWhiteSpace(txtDishname.Text))
            {
                MessageBox.Show("Dish name is required.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirection.Text))
            {
                MessageBox.Show("Directions are required.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (lstIngredients.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.", "Missing Ingredients", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboCourses.SelectedItem == null)
            {
                MessageBox.Show("Please select a course.", "Missing Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            lstIngredients.Items.Clear();
            ClearInputs();
            txtDirection.Clear();
            txtDishname.Clear();
            pictureBoxRecipe.Image = null;
            cboCourses.SelectedIndex = -1;
            cboMeasurement.SelectedIndex = -1;
        }

        private int GetCategoryId(string categoryName)
        {
            try
            {
                string sql = "SELECT category_id FROM categories WHERE category_name = @name";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", categoryName);
                    object res = cmd.ExecuteScalar();
                    return res != null ? Convert.ToInt32(res) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting category ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void btnImportUrl_Click(object sender, EventArgs e)
        {
            frmImportPage frmImportPage = new frmImportPage(userId);
            frmImportPage.ShowDialog();

            if (frmImportPage.ImportedRecipe != null)
            {
                frmRecipe importedRecipeForm = new frmRecipe(userId, frmImportPage.ImportedRecipe);
                importedRecipeForm.ShowDialog();
            }
            this.Show();
        }

        private void txtScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
                e.Handled = true;
        }

        private void txtScale_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtScale.Text))
            {
                if (float.TryParse(txtScale.Text, out float value))
                {
                    if (value < 0.01f || value > 100f)
                    {
                        MessageBox.Show("Please enter a value between 0.01 and 100.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number format.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
