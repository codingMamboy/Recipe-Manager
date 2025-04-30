using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmViewRecipe : Form
    {
        private int recipeId;

        public frmViewRecipe(int recipeId)
        {
            InitializeComponent();
            this.recipeId = recipeId;
            this.Load += frmViewRecipe_Load;
        }

        private void frmViewRecipe_Load(object sender, EventArgs e)
        {


            txtIngredients.Multiline = true;
            txtInstructions.Multiline = true;

            // Set font
            txtIngredients.Font = new Font("Segoe UI", 10);
            txtInstructions.Font = new Font("Segoe UI", 10);

            // Optional: Word wrap happens automatically in Guna2TextBox
            // Set ReadOnly if it's just for viewing
            txtIngredients.ReadOnly = true;
            txtInstructions.ReadOnly = true;

            // Set background and foreground colors for visibility
            txtIngredients.FillColor = Color.White;
            txtIngredients.ForeColor = Color.Black;

            txtInstructions.FillColor = Color.White;
            txtInstructions.ForeColor = Color.Black;

            // Optional: Set border radius or shadow for aesthetics
            txtIngredients.BorderRadius = 5;
            txtInstructions.BorderRadius = 5;

            txtIngredients.ReadOnly = true;
            txtInstructions.ReadOnly = true;

            string connectionString = @"server=localhost;user=root;password=12345;database=recipe_managerv2;";
            string query = @"SELECT r.recipe_name, r.ingredients, r.instructions, r.image_path, c.category_name 
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
                                lblRecipeName.Text = reader["recipe_name"].ToString();
                                txtIngredients.Text = reader["ingredients"].ToString();
                                txtInstructions.Text = reader["instructions"].ToString();
                                lblCourse.Text = reader["category_name"].ToString();

                                string imagePath = reader["image_path"].ToString();

                                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                                {
                                    pictureboxRecipe.SizeMode = PictureBoxSizeMode.StretchImage; // Stretch to fill
                                    pictureboxRecipe.Image = Image.FromFile(imagePath);
                                }
                                else
                                {
                                    pictureboxRecipe.Image = null;
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

        private void txtInstructions_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmViewRecipe_Load_1(object sender, EventArgs e)
        {

        }
    }
}
