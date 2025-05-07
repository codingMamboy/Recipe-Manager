// Required namespaces
using MySql.Data.MySqlClient;       // Provides classes for MySQL database access
using System;                       // Core system functions like Exception, EventArgs, etc.
using System.Drawing;              // Used for GUI component styling (fonts, colors)
using System.Windows.Forms;        // Windows Forms controls (Form, Button, Label, etc.)
using Guna.UI2.WinForms;           // Guna UI framework for enhanced visual components

namespace Recipe_Manager
{
    public partial class frmHome : Form
    {
        // --- DATABASE FIELDS ---

        // Connection string used to connect to your MySQL database
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // MySqlConnection object reused across queries
        private readonly MySqlConnection conn;

        // Stores the ID of the user currently logged in (used for personalized data access)
        private readonly int userId;

        // --- CONSTRUCTOR ---

        // Constructor receives the userId from the login form
        public frmHome(int userId)
        {
            InitializeComponent(); // Initializes the form controls (designer code)

            conn = new MySqlConnection(connectionString); // Instantiate DB connection
            this.userId = userId; // Save the logged-in user's ID

            // Attach an event handler for real-time search when the user types in the search bar
            txtSearchbar.TextChanged += txtSearchbar_TextChanged;
        }

        // --- FORM LOAD EVENT ---

        // This method runs automatically when the form loads
        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                // Prepare a SQL query to fetch the user's username from the database
                string query = "SELECT username FROM users WHERE user_id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId); // Bind the userId to the query

                conn.Open(); // Open DB connection
                MySqlDataReader reader = cmd.ExecuteReader(); // Execute the query

                if (reader.Read())
                {
                    // If the user was found, personalize the welcome button text
                    btnWelcome.Text = "Welcome, " + reader["username"].ToString();
                }

                reader.Close();  // Important: Close the reader before using the connection again
                conn.Close();    // Close DB connection after read

                // Load all the user's recipes into the flow panel (cards/buttons)
                LoadRecipesToPanel();
            }
            catch (Exception ex)
            {
                // Catch and show any error during user loading
                MessageBox.Show("Error loading user data: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LOAD RECIPES TO FLOW PANEL ---

        // This function loads recipes into the flow panel (optionally filtered by a search string)
        private void LoadRecipesToPanel(string search = "")
        {
            // Clear previously loaded recipe buttons before reloading
            flowRecipeMenu.Controls.Clear();

            try
            {
                conn.Open(); // Open the DB connection

                // SQL query to retrieve recipes owned by the user and filtered by search term
                string query = @"
                SELECT recipe_id, recipe_name
                FROM recipes
                WHERE user_id = @userId
                  AND recipe_name LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@search", $"%{search}%"); // Wildcard search

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    bool foundRecipes = false;

                    // Loop through each recipe returned from the DB
                    while (reader.Read())
                    {
                        int recipeId = Convert.ToInt32(reader["recipe_id"]);
                        string recipeName = reader["recipe_name"].ToString();

                        // Dynamically create a Guna2Button to represent the recipe
                        var recipeButton = new Guna2Button
                        {
                            Width = 180,
                            Height = 70,
                            Font = new Font("Poppins", 10),
                            FillColor = Color.FromArgb(233, 118, 43), // Orange shade
                            ForeColor = Color.White,
                            Text = recipeName, // Recipe title
                            Tag = recipeId,    // Store recipe ID for reference
                            Margin = new Padding(18), // Padding around each button
                            BorderRadius = 3,   // Rounded corners
                            Cursor = Cursors.Hand,
                            Animated = true     // Enables animation effects
                        };

                        // Click event opens the detailed view of the selected recipe
                        recipeButton.Click += (s, e) =>
                        {
                            var viewForm = new frmViewRecipe(recipeId, userId); // Pass ID to view form
                            this.Hide();
                            viewForm.Show();
                        };

                        // Add the button to the flow layout panel
                        flowRecipeMenu.Controls.Add(recipeButton);
                        foundRecipes = true;
                    }

                    // If no recipes were found, show a message label
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
                // Display any errors that occur during the recipe load
                MessageBox.Show("Failed to load recipes: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure the DB connection is always closed
            }
        }

        // --- SEARCH FUNCTIONALITY ---

        // This event is triggered whenever the user types in the search bar
        private void txtSearchbar_TextChanged(object sender, EventArgs e)
        {
            LoadRecipesToPanel(txtSearchbar.Text.Trim()); // Refresh recipe list with search filter
        }

        // --- BUTTON EVENTS FOR NAVIGATION ---

        // Opens the Add Recipe form when the recipe button is clicked
        private void btnRecipe_Click(object sender, EventArgs e)
        {
            var addForm = new frmRecipe(userId); // Open Add Recipe form with current user
            this.Close();
            addForm.Show();
        }

        // Duplicate functionality: also opens the Add Recipe form
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            var addForm = new frmRecipe(userId);
            this.Close();
            addForm.Show();
        }

        // Opens the Remove Recipe form
        private void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            var removeForm = new frmRemoveRecipe(userId);
            this.Close();
            removeForm.Show();
        }

        // Exit the entire application when clicked
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Opens the user profile form
        private void btnWelcome_Click(object sender, EventArgs e)
        {
            var frmProfile = new frmProfile(userId); // Navigate to profile
            this.Close();
            frmProfile.Show();
        }

        // Opens the Meal Planner form
        private void btnPlanner_Click(object sender, EventArgs e)
        {
            var frmPlanner = new frmPlanner(userId); // Navigate to planner
            this.Close();
            frmPlanner.Show();
        }
    }
}
