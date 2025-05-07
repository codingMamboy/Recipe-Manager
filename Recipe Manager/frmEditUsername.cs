using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmEditUsername : Form
    {
        // Stores the ID and current username of the logged-in user
        private int userId;
        private string currentUsername;

        // MySQL database connection string
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // Constructor that sets up the form and initializes userId and currentUsername
        // It also sets the current username in the username textbox
        public frmEditUsername(int userId, string currentUsername)
        {
            InitializeComponent();  // Initializes the form components
            this.userId = userId;   // Stores the userId for database operations
            this.currentUsername = currentUsername;  // Stores the current username
            txtUsername.Text = currentUsername;  // Sets the current username into the username text box
        }

        // Handles the update button click event to change the username
        private void btnUpdateUsername_Click(object sender, EventArgs e)
        {
            string newUsername = txtUsername.Text.Trim();  // Retrieves the new username entered by the user

            // Input validation checks for empty or unchanged username
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a new username.");  // Displays an error if the username is empty
                return;
            }

            if (newUsername == currentUsername)
            {
                MessageBox.Show("This is the same as your current username.");  // Displays an error if the new username is the same as the current username
                return;
            }

            try
            {
                // Establish a MySQL connection and check if the new username already exists
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();  // Open the connection to the database

                    // Query to check if the new username already exists in the database
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", newUsername);  // Adds the new username as a parameter
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());  // Executes the query and gets the count

                    // Prevent updating if username already exists
                    if (count > 0)
                    {
                        MessageBox.Show("This username is already taken. Please choose another one.");  // Displays an error if the username is already taken
                        return;
                    }

                    // If the username is available, update it in the database
                    string updateQuery = "UPDATE users SET username = @newUsername WHERE user_id = @userId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newUsername", newUsername);  // Adds the new username as a parameter
                    updateCmd.Parameters.AddWithValue("@userId", userId);  // Adds the user ID to ensure we update the correct user
                    updateCmd.ExecuteNonQuery();  // Executes the update query to change the username

                    MessageBox.Show("Username updated successfully.");  // Displays success message

                    // Close the form and return with OK result to indicate successful update
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);  // Displays error if any exception occurs during the process
            }
        }

        // Handles the Back button click to return to the profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();  // Hide the current form (frmEditUsername)

            using (frmProfile frmProfile = new frmProfile(userId))  // Create and show the profile form
            {
                frmProfile.ShowDialog();  // Display the profile form as a dialog
            }

            this.Close();  // Close the current form after returning from profile
        }

        // Closes the application when Exit is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Exit the application when the Exit button is clicked
        }
    }
}
