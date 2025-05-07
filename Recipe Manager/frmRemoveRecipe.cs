using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmRemoveRecipe : Form
    {
        // Connection string to the MySQL database
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // Stores the ID of the currently logged-in user
        private readonly int userId;

        // Constructor that initializes the form with the user's ID
        public frmRemoveRecipe(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        // Event triggered when the form is loaded
        private void frmRemoveRecipe_Load(object sender, EventArgs e)
        {
            LoadUserRecipes();  // Load the user's recipes into the ComboBox
        }

        // Loads the recipes created by the current user into the ComboBox
        private void LoadUserRecipes()
        {
            comboBoxRecipes.Items.Clear();  // Clear previous items

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to fetch recipe IDs and names for the current user
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

                                // Add the recipe as a RecipeItem object to the ComboBox
                                comboBoxRecipes.Items.Add(new RecipeItem(recipeId, recipeName));
                            }
                        }
                    }
                }

                // Set the first item as selected if recipes exist
                if (comboBoxRecipes.Items.Count > 0)
                    comboBoxRecipes.SelectedIndex = 0;
                else
                    comboBoxRecipes.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipes: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event triggered when the "Delete" button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a valid recipe is selected
            if (!(comboBoxRecipes.SelectedItem is RecipeItem selectedRecipe))
                return;

            // Ask the user to confirm deletion
            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedRecipe.Name}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the recipe is linked to any plans
                    string checkSql = @"
                        SELECT COUNT(*)
                        FROM plans
                        WHERE recipe_id = @recipeId";

                    using (var checkCmd = new MySqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@recipeId", selectedRecipe.Id);
                        int planCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (planCount > 0)
                        {
                            // Warn user about cascading deletions
                            var cascadeResult = MessageBox.Show(
                                $"This recipe is used in {planCount} plan(s). Deleting it will also remove those plans. Continue?",
                                "Cascade Delete Warning",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning
                            );
                            if (cascadeResult != DialogResult.Yes)
                                return;
                        }
                    }

                    // Delete the recipe only if it belongs to the current user
                    string deleteSql = @"
                        DELETE FROM recipes
                        WHERE recipe_id = @recipeId
                        AND user_id = @userId";

                    using (var deleteCmd = new MySqlCommand(deleteSql, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@recipeId", selectedRecipe.Id);
                        deleteCmd.Parameters.AddWithValue("@userId", userId);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No recipe was deleted. Please check recipe ID and user ID.",
                                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Recipe deleted successfully.",
                                            "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserRecipes();  // Refresh the ComboBox list
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting recipe: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navigates back to the home form
        private void btnBack_Click(object sender, EventArgs e)
        {
            var homeForm = new frmHome(userId);
            this.Close();  // Close current form
            homeForm.Show();  // Open the home form
        }

        // Closes the entire application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // Helper class to represent an item in the ComboBox (ID + Name)
    public class RecipeItem
    {
        public int Id { get; }         // Recipe ID
        public string Name { get; }    // Recipe name

        public RecipeItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Override ToString to display only the name in the ComboBox
        public override string ToString() => Name;
    }
}
