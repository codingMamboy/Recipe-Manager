using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmRemoveRecipe : Form
    {
        private int userId;
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        public frmRemoveRecipe(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserRecipes();
        }

    private void LoadUserRecipes()
        {
            comboBoxRecipes.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT recipe_id, recipe_name FROM recipes WHERE user_id = @userId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int recipeId = reader.GetInt32("recipe_id");
                                string recipeName = reader.GetString("recipe_name");
                                comboBoxRecipes.Items.Add(new RecipeItem(recipeId, recipeName));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading recipes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (comboBoxRecipes.Items.Count > 0)
                comboBoxRecipes.SelectedIndex = 0;
        }


    private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxRecipes.SelectedItem is RecipeItem selectedRecipe)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete '{selectedRecipe.Name}'?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM recipes WHERE recipe_id = @recipeId AND user_id = @userId";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@recipeId", selectedRecipe.Id);
                                cmd.Parameters.AddWithValue("@userId", userId);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Recipe deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUserRecipes();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting recipe: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    private void btnBack_Click(object sender, EventArgs e)
        {
            frmHome homeForm = new frmHome(userId);
            this.Hide();
            homeForm.Show();
        }
    }

    public class RecipeItem
    {
        public int Id { get; }
        public string Name { get; }

        public RecipeItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
