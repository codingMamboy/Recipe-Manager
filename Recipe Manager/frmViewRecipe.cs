using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Recipe_Manager
{
    public partial class frmViewRecipe : Form
    {
        private int recipeId;
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // Constructor that accepts a recipeId
        public frmViewRecipe(int recipeId)
        {
            InitializeComponent();
            this.recipeId = recipeId; // Store the recipeId to be used later
        }

        private void frmViewRecipe_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecipeDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipe details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecipeDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT recipe_name, ingredients, instructions FROM recipes WHERE recipe_id = @recipeId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@recipeId", recipeId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Load the recipe name, ingredients, and instructions into your controls (e.g., labels, textboxes)
                    string recipeName = reader["recipe_name"].ToString();
                    string ingredients = reader["ingredients"].ToString();
                    string instructions = reader["instructions"].ToString();

                    lblRecipeName.Text = recipeName;  // Assuming you have a label for recipe name
                    txtIngredients.Text = ingredients;  // Assuming you have a textbox for ingredients
                    txtInstructions.Text = instructions;  // Assuming you have a textbox for instructions
                }
                else
                {
                    MessageBox.Show("Recipe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
