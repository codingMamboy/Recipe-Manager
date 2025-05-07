using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;  // (not used in this code, can be removed)
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmViewRecipe : Form
    {
        private int recipeId;
        private int userId;

        // Constructor receives both the selected recipe ID and the logged-in user ID
        public frmViewRecipe(int recipeId, int userId)
        {
            InitializeComponent();
            this.recipeId = recipeId;
            this.userId = userId;

            // Dynamically bind the load event to the method
            this.Load += frmViewRecipe_Load;
        }

        // Main form load logic - populates all fields with the selected recipe's data
        private void frmViewRecipe_Load(object sender, EventArgs e)
        {
            // DB connection string and SQL to fetch the recipe and its category
            string connectionString = @"server=localhost;user=root;password=12345;database=recipe_managerv2;";
            string query = @"
                SELECT r.recipe_name, r.ingredients, r.instructions, r.image_path, c.category_name 
                FROM recipes r
                INNER JOIN categories c ON r.category_id = c.category_id
                WHERE r.recipe_id = @recipeId";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@recipeId", recipeId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate form fields with recipe data
                                lblRecipeName.Text = reader["recipe_name"].ToString();
                                txtIngredients.Text = reader["ingredients"].ToString();
                                txtInstructions.Text = reader["instructions"].ToString();
                                lblCourse.Text = reader["category_name"].ToString();

                                string imagePath = reader["image_path"].ToString();

                                // Display recipe image if the file exists
                                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                                {
                                    pictureboxRecipe.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureboxRecipe.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    pictureboxRecipe.Image = null;  // No image or invalid path
                                }
                            }
                            else
                            {
                                MessageBox.Show("Recipe not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipe: " + ex.Message);
            }
        }

        // Unused event handlers (safe to remove unless needed later)
        private void txtInstructions_TextChanged(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void frmViewRecipe_Load_1(object sender, EventArgs e) { }

        // Back button returns to the home screen
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome(userId);
            this.Close();
            frmHome.ShowDialog();  // Using ShowDialog blocks current thread until closed
        }

        // Exit button closes the entire application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
