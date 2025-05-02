using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmRemoveRecipe : Form
    {
        // Connection string to the recipe manager database
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private readonly int userId;  // Currently logged-in user's ID

        // Constructor: stores the userId and immediately loads their recipes
        public frmRemoveRecipe(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserRecipes();
        }

        // Fetches all recipes belonging to the current user
        // and populates the comboBoxRecipes dropdown.
        private void LoadUserRecipes()
        {
            comboBoxRecipes.Items.Clear();  // Clear any existing items

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();  // Open DB connection

                    string query = @"
                        SELECT recipe_id, recipe_name
                          FROM recipes
                         WHERE user_id = @userId";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (var reader = cmd.ExecuteReader())
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
                    MessageBox.Show(
                        "Error loading recipes: " + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            // If we got at least one recipe, select the first by default
            if (comboBoxRecipes.Items.Count > 0)
                comboBoxRecipes.SelectedIndex = 0;
        }

        // Handles the Delete button click:
        // 1) Confirms deletion,
        // 2) Deletes the record from the database,
        // 3) Reloads the combo box.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(comboBoxRecipes.SelectedItem is RecipeItem selectedRecipe))
                return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedRecipe.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result != DialogResult.Yes)
                return;

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();  // Open DB connection

                    string deleteSql = @"
                        DELETE FROM recipes
                         WHERE recipe_id = @recipeId
                           AND user_id = @userId";
                    using (var cmd = new MySqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@recipeId", selectedRecipe.Id);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        cmd.ExecuteNonQuery();  // Execute deletion
                    }

                    MessageBox.Show(
                        "Recipe deleted successfully.",
                        "Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LoadUserRecipes();  // Reload combo box to reflect changes
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error deleting recipe: " + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // Handles the Back button click:
        // hides this form and returns to the main home screen.
        private void btnBack_Click(object sender, EventArgs e)
        {
            var homeForm = new frmHome(userId);
            Hide();       // Hide current form
            homeForm.Show();
        }

        // Handles the Exit button click by terminating the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // Simple class to hold a recipe's ID and Name.
    // Overriding ToString() allows the combo box to display the name.
    public class RecipeItem
    {
        public int Id { get; }
        public string Name { get; }

        public RecipeItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
