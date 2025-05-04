using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Recipe_Manager
{
    public partial class frmHome : Form
    {
        // Database connection string and connection object
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private readonly MySqlConnection conn;
        private readonly int userId; // Stores the currently logged-in user's ID

        // Constructor with userId passed from login/signup
        public frmHome(int userId)
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
            this.userId = userId;

            // Attach real-time search event handler
            txtSearchbar.TextChanged += txtSearchbar_TextChanged;
        }

        // Load user details and recipes on form load
        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                // Query to get the logged-in user's username
                string query = "SELECT username FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Display welcome message using username
                    btnWelcome.Text = "Welcome, " + reader["username"].ToString();
                }

                reader.Close();  // Close the reader before executing other queries
                conn.Close();

                // Load the list of recipes into the panel
                LoadRecipesToPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecipesToPanel(string search = "")
        {
            // Clear existing controls to refresh the panel
            flowRecipeMenu.Controls.Clear();

            try
            {
                conn.Open();

                // SQL query to fetch recipe names and IDs matching the search keyword
                string query = @"
            SELECT recipe_id, recipe_name
            FROM recipes
            WHERE user_id = @userId
              AND recipe_name LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@search", $"%{search}%");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    bool foundRecipes = false;  // Flag to check if any recipes are found

                    while (reader.Read())
                    {
                        int recipeId = Convert.ToInt32(reader["recipe_id"]);
                        string recipeName = reader["recipe_name"].ToString();

                        // Create and configure a Guna2Button for each recipe
                        var recipeButton = new Guna2Button
                        {
                            Width = 180,
                            Height = 70,
                            Font = new Font("Poppins", 10),
                            FillColor = Color.FromArgb(233, 118, 43),
                            ForeColor = Color.White,
                            Text = recipeName,
                            Tag = recipeId,
                            Margin = new Padding(18),
                            BorderRadius = 3,
                            Cursor = Cursors.Hand,
                            Animated = true
                        };

                        // Event handler to open the selected recipe
                        recipeButton.Click += (s, e) =>
                        {
                            var viewForm = new frmViewRecipe(recipeId, userId);
                            this.Hide();
                            viewForm.Show();
                        };

                        // Add the button to the panel
                        flowRecipeMenu.Controls.Add(recipeButton);

                        foundRecipes = true;  // Mark that we found recipes
                    }

                    // If no recipes are found, display a "No Recipe Found" message
                    if (!foundRecipes)
                    {
                        var noRecipeLabel = new Label
                        {
                            Text = "No Recipe Found",
                            Font = new Font("Poppins", 12, FontStyle.Italic),
                            ForeColor = Color.Gray,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Width = 630,
                            Height = 70,
                            Margin = new Padding(18)
                        };
                        flowRecipeMenu.Controls.Add(noRecipeLabel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load recipes: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        // Real-time search: triggers whenever text changes in the search bar
        private void txtSearchbar_TextChanged(object sender, EventArgs e)
        {
            LoadRecipesToPanel(txtSearchbar.Text.Trim());
        }

        // Open the Add Recipe form
        private void btnRecipe_Click(object sender, EventArgs e)
        {
            var addForm = new frmRecipe(userId);
            this.Close();
            addForm.Show();
        }

        // Another button for adding recipes (duplicate functionality)
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            var addForm = new frmRecipe(userId);
            this.Close();
            addForm.Show();
        }

        // Open the Remove Recipe form
        private void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            var removeForm = new frmRemoveRecipe(userId);
            this.Close();
            removeForm.Show();
        }

        // Exit the application
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Navigate to the profile form
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
    }
}
