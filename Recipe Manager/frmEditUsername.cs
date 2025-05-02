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

        // Constructor sets up form fields and displays the current username
        public frmEditUsername(int userId, string currentUsername)
        {
            InitializeComponent();
            this.userId = userId;
            this.currentUsername = currentUsername;
            txtUsername.Text = currentUsername;
        }

        // Handles the update button click event to change the username
        private void btnUpdateUsername_Click(object sender, EventArgs e)
        {
            string newUsername = txtUsername.Text.Trim();

            // Input validation checks for empty or unchanged username
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a new username.");
                return;
            }

            if (newUsername == currentUsername)
            {
                MessageBox.Show("This is the same as your current username.");
                return;
            }

            try
            {
                // Establish a MySQL connection and check if the new username already exists
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", newUsername);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    // Prevent updating if username already exists
                    if (count > 0)
                    {
                        MessageBox.Show("This username is already taken. Please choose another one.");
                        return;
                    }

                    // Update the username in the database
                    string updateQuery = "UPDATE users SET username = @newUsername WHERE user_id = @userId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newUsername", newUsername);
                    updateCmd.Parameters.AddWithValue("@userId", userId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Username updated successfully.");

                    // Close the form and return with OK result
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Handles the Back button click to return to the profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (frmProfile frmProfile = new frmProfile(userId))
            {
                frmProfile.ShowDialog();
            }

            this.Close();
        }

        // Closes the application when Exit is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
