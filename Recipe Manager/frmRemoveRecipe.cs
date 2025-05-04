using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmRemoveRecipe : Form
    {
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private readonly int userId;

        public frmRemoveRecipe(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void frmRemoveRecipe_Load(object sender, EventArgs e)
        {
            LoadUserRecipes();
        }

        private void LoadUserRecipes()
        {
            comboBoxRecipes.Items.Clear();

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

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

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check for linked plans
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
                            LoadUserRecipes();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            var homeForm = new frmHome(userId);
            this.Close();
            homeForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public override string ToString() => Name;
    }
}
