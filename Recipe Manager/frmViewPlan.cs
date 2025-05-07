using MySql.Data.MySqlClient; // Imports MySQL library to interact with the database
using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Recipe_Manager
{
    // This form is used to view the details of a specific plan (recipe plan for a user)
    public partial class frmViewPlan : Form
    {
        private int planId;  // Holds the ID of the plan being viewed
        private int userId;  // Holds the ID of the logged-in user

        // Constructor to initialize form with planId and userId
        public frmViewPlan(int planId, int userId)
        {
            InitializeComponent();  // Initializes components (UI controls) on the form
            this.planId = planId;  // Sets the planId to the passed parameter
            this.userId = userId;  // Sets the userId to the passed parameter
        }

        // Event handler for loading the form
        private void frmViewPlan_Load(object sender, EventArgs e)
        {
            // Connection string to connect to the MySQL database
            string connectionString = @"server=localhost;user=root;password=12345;database=recipe_managerv2;";

            // SQL query to fetch details of the plan, including the recipe, category, and image
            string query = @"
            SELECT 
                p.plan_date,        // Plan date
                p.notes,            // Notes for the plan
                r.recipe_name,      // Recipe name
                c.category_name,    // Category of the recipe
                r.image_path        // Image path of the recipe
            FROM plans p
            INNER JOIN recipes r ON p.recipe_id = r.recipe_id
            INNER JOIN categories c ON r.category_id = c.category_id
            WHERE p.plan_id = @planId AND p.user_id = @userId";  // Filters for the specific plan and user

            try
            {
                // Establishing a connection to the database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();  // Opens the connection

                    // Creating a MySQL command to execute the query
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Adding parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@planId", planId);
                        command.Parameters.AddWithValue("@userId", userId);

                        // Executing the query and reading the result
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // If a matching plan is found
                            {
                                // Assign values from the database to UI elements
                                lblDate.Text = Convert.ToDateTime(reader["plan_date"]).ToString("dddd, d MMMM yyyy");
                                lblRecipeName.Text = reader["recipe_name"].ToString();
                                lblCourse.Text = reader["category_name"].ToString();
                                txtNotes.Text = reader["notes"].ToString();  // Show notes for the plan

                                // Handling image display
                                string imagePath = reader["image_path"].ToString();
                                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))  // Check if the image exists
                                {
                                    pictureboxRecipe.SizeMode = PictureBoxSizeMode.StretchImage;  // Adjust the size mode for better display
                                    pictureboxRecipe.Image = Image.FromFile(imagePath);  // Load the image into the picture box
                                }
                                else
                                {
                                    pictureboxRecipe.Image = null;  // Set a default or empty image if the image is not found
                                }
                            }
                            else
                            {
                                MessageBox.Show("Plan not found.");  // Show message if no plan was found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message if there was an issue with loading the plan
                MessageBox.Show("Error loading plan: " + ex.Message);
            }
        }

        // Event handler for the delete button to remove a plan
        private void btnDeletePLam_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before deleting
            if (MessageBox.Show(
                    "Are you sure you want to delete this plan?",  // Confirmation message
                    "Confirm Delete",  // Title of the message box
                    MessageBoxButtons.YesNo,  // Yes or No options
                    MessageBoxIcon.Warning  // Warning icon
                ) != DialogResult.Yes)
                return;  // If the user clicks No, exit the method without doing anything

            // Connection string for the database
            string cs = @"server=localhost;uid=root;pwd=12345;database=recipe_managerv2;";

            try
            {
                // Establishing a connection to the database
                using (var conn = new MySqlConnection(cs))
                {
                    conn.Open();  // Open the connection
                    using (var cmd = conn.CreateCommand())
                    {
                        // SQL command to delete the plan from the database
                        cmd.CommandText = "DELETE FROM plans WHERE plan_id = @planId AND user_id = @userId";
                        cmd.Parameters.AddWithValue("@planId", planId);  // Add the planId parameter
                        cmd.Parameters.AddWithValue("@userId", userId);  // Add the userId parameter

                        int rows = cmd.ExecuteNonQuery();  // Execute the delete command

                        if (rows > 0)
                            MessageBox.Show("Plan deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Notify if deletion was successful
                        else
                            MessageBox.Show("No matching plan found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Notify if no plan was found
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message if there was an issue with deleting the plan
                MessageBox.Show("Error deleting plan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the current view and return to the planner form (which will refresh itself)
            this.Close();

            var frmPlanner = new frmPlanner(userId);  // Create a new instance of the planner form
            frmPlanner.Show();  // Show the planner form
        }

        // Event handler for the Back button to return to the planner form
        private void btnBack_Click(object sender, EventArgs e)
        {
            var frmPlanner = new frmPlanner(userId);  // Create a new instance of the planner form
            this.Close();  // Close the current form
            frmPlanner.Show();  // Show the planner form
        }
    }
}
