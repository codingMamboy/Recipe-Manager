using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmProfile : Form
    {
        // Stores the currently logged-in user's ID
        private readonly int userId;

        // Stores the user's current email and username
        private string currentEmail = "";
        private string currentUsername = "";

        // Connection string to the MySQL database
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";

        // Constructor - Initializes the form and loads user info
        public frmProfile(int userId)
        {
            InitializeComponent();  // Initializes the form controls
            this.userId = userId;   // Sets the userId passed to the form
            LoadUserInfo();         // Loads the user data when the form is created
        }

        // Sets the cursor to "hand" when hovering over clickable labels
        private void frmProfile_Load(object sender, EventArgs e)
        {
            lblChangeEmail.Cursor = Cursors.Hand;  // Set cursor for Change Email label
            lblEditUsername.Cursor = Cursors.Hand; // Set cursor for Edit Username label
        }

        // Loads the current username and email from the database and displays them on the form
        private void LoadUserInfo()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();  // Open connection to the MySQL database

                // SQL query to retrieve the username and email based on userId
                const string query = "SELECT username, email FROM users WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Adding parameter to avoid SQL injection
                    cmd.Parameters.AddWithValue("@userId", userId);

                    // Execute the query and read the data
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())  // If data is found for the user
                        {
                            currentUsername = reader.GetString("username");  // Retrieve the username
                            currentEmail = reader.GetString("email");        // Retrieve the email

                            // Update the labels with the user's current username and email
                            lblUsername.Text = currentUsername;
                            lblEmail.Text = currentEmail;
                        }
                    }
                }
            }
        }

        // Opens the "Change Password" form and hides the profile form while it's active
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();  // Hide the profile form

            // Create an instance of the Change Password form and pass userId
            using (var changePwd = new frmChangePassword(userId))
            {
                changePwd.ShowDialog();  // Show the Change Password form and wait for it to close
            }

            this.Show();  // Once the password form is closed, show the profile form again
        }

        // Opens the "Edit Username" form; if the user saves changes, reload the user info
        private void lblEditUsername_Click(object sender, EventArgs e)
        {
            using (var editUser = new frmEditUsername(userId, currentUsername))
            {
                this.Hide();  // Hide the profile form while editing the username

                if (editUser.ShowDialog() == DialogResult.OK)  // If the user confirms changes
                {
                    LoadUserInfo();  // Reload the user information to show updated username
                }

                this.Show();  // Show the profile form again
            }
        }

        // Opens the "Change Email" form; if email is changed, reload the user info
        private void lblChangeEmail_Click_1(object sender, EventArgs e)
        {
            using (var changeEmail = new frmChangeEmail(userId, currentEmail))
            {
                this.Hide();  // Hide the profile form while changing email

                if (changeEmail.ShowDialog() == DialogResult.OK)  // If the user confirms changes
                {
                    LoadUserInfo();  // Reload the user information to show updated email
                }

                this.Show();  // Show the profile form again
            }
        }

        // Returns to the Home form, closing the Profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();  // Hide the profile form

            using (frmHome homeForm = new frmHome(userId))  // Create an instance of the Home form
            {
                homeForm.ShowDialog();  // Show the Home form and wait for it to close
            }

            this.Close();  // Once the home form is closed, close the profile form
        }

        // Exits the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Closes the entire application
        }
    }
}
