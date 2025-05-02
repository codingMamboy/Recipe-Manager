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
            InitializeComponent();
            this.userId = userId;
            LoadUserInfo(); // Load user data on form creation
        }

        // Sets cursor to "hand" when hovering over clickable labels
        private void frmProfile_Load(object sender, EventArgs e)
        {
            lblChangeEmail.Cursor = Cursors.Hand;
            lblEditUsername.Cursor = Cursors.Hand;
        }

        // Loads the current username and email from the database and displays them on the form
        private void LoadUserInfo()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                const string query = "SELECT username, email FROM users WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentUsername = reader.GetString("username");
                            currentEmail = reader.GetString("email");

                            // Update labels with retrieved values
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
            this.Hide();

            using (var changePwd = new frmChangePassword(userId))
            {
                changePwd.ShowDialog(); // Wait for password form to close
            }

            this.Show();
        }

        // Opens the "Edit Username" form; if the user saves changes, reload the user info
        private void lblEditUsername_Click(object sender, EventArgs e)
        {
            using (var editUser = new frmEditUsername(userId, currentUsername))
            {
                this.Hide();

                if (editUser.ShowDialog() == DialogResult.OK)
                {
                    LoadUserInfo(); // Refresh the username on profile page
                }

                this.Show();
            }
        }

        // Opens the "Change Email" form; if email is changed, reload the user info
        private void lblChangeEmail_Click_1(object sender, EventArgs e)
        {
            using (var changeEmail = new frmChangeEmail(userId, currentEmail))
            {
                this.Hide();

                if (changeEmail.ShowDialog() == DialogResult.OK)
                {
                    LoadUserInfo(); // Refresh the email on profile page
                }

                this.Show();
            }
        }

        // Returns to the Home form, closing the Profile form
        private void btnBack2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (frmHome homeForm = new frmHome(userId))
            {
                homeForm.ShowDialog(); // Show home screen
            }

            this.Close(); // Close profile form
        }

        // Exits the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
