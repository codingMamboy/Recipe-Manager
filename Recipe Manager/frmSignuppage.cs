// Import required namespaces
using System;                             // Base .NET types
using System.Net;                         // For handling network credentials
using System.Net.Mail;                    // For sending emails
using System.Security.Cryptography;       // For hashing passwords securely
using System.Text;                        // For text encoding
using System.Windows.Forms;               // For Windows Forms GUI components
using MySql.Data.MySqlClient;             // For MySQL database interaction

namespace Recipe_Manager
{
    public partial class frmSignuppage : Form
    {
        // Database connection string to connect to local MySQL server
        private readonly string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn; // Object to manage MySQL connection
        private string verificationCode; // Holds generated 6-digit email verification code

        public frmSignuppage()
        {
            InitializeComponent(); // Initializes UI components
            conn = new MySqlConnection(connectionString); // Initializes the database connection
        }

        private void frmSignuppage_Load(object sender, EventArgs e)
        {
            // Placeholder: runs when form loads (not used yet)
        }

        private void btnExit2_Click(object sender, EventArgs e) => Application.Exit(); // Exits the app

        private void btnSignin_Click(object sender, EventArgs e)
        {
            // Opens login form and hides the current sign-up form
            new frmLoginpage().Show();
            this.Hide();
        }

        private void tbxPwd2_TextChanged(object sender, EventArgs e) => tbxPwd2.UseSystemPasswordChar = true; // Hides password as dots

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e) => tbxConfirmpwd.UseSystemPasswordChar = true; // Hides confirm password as dots

        // Main logic when the "Sign Up" button is clicked
        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Disable button and change text to indicate progress
            SetSignupButtonState(false, "Registering...");

            // Retrieve and trim input values from textboxes
            string username = tbxUsername2.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string password = tbxPwd2.Text.Trim();
            string confirmPwd = tbxConfirmpwd.Text.Trim();
            string codeInput = tbxCode2.Text.Trim();

            // Check if any fields are empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPwd) ||
                string.IsNullOrWhiteSpace(codeInput))
            {
                ShowWarning("All fields are required.");
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                ShowWarning("Please enter a valid email address.");
                return;
            }

            // Ensure password and confirm password match
            if (password != confirmPwd)
            {
                ShowWarning("Passwords do not match.");
                return;
            }

            // Check if entered verification code matches the generated one
            if (codeInput != verificationCode)
            {
                ShowError("Incorrect verification code.");
                return;
            }

            try
            {
                conn.Open(); // Open database connection

                // Check if username or email already exists
                using (var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @username OR email = @email", conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    checkCmd.Parameters.AddWithValue("@email", email);

                    // Execute and check if count is greater than zero
                    if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                    {
                        ShowError("Username or email already exists.");
                        return;
                    }
                }

                // Hash password using SHA-256
                string hashedPassword = HashPassword(password);

                // Insert new user into database
                using (var insertCmd = new MySqlCommand("INSERT INTO users (username, email, password_hash) VALUES (@username, @email, @password_hash)", conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@password_hash", hashedPassword);

                    // Check if insertion was successful
                    if (insertCmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optionally send a success email
                        SendConfirmationEmail(email);

                        // Redirect to login
                        new frmLoginpage().Show();
                        this.Hide();
                    }
                    else
                    {
                        ShowError("Sign-up failed. Try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any DB or logic errors
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Always close DB connection
                SetSignupButtonState(true); // Re-enable sign-up button
            }
        }

        // Logic for when "Send Code" button is clicked
        private void btnCodeVerification1_Click(object sender, EventArgs e)
        {
            string email = tbxEmail.Text.Trim(); // Get trimmed email

            // Validate email before sending code
            if (!IsValidEmail(email))
            {
                ShowWarning("Please enter a valid email address.");
                return;
            }

            SetCodeButtonState(false, "Sending..."); // Disable button while sending

            // Generate a 6-digit random code
            verificationCode = new Random().Next(100000, 999999).ToString();

            // Send the code to the given email
            SendConfirmationEmail(email, verificationCode);

            MessageBox.Show("Verification code sent. Check your email.", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbxEmail.Enabled = false; // Disable email field to prevent change

            SetCodeButtonState(true); // Re-enable button
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Show login form as dialog and hide this form
            new frmLoginpage().ShowDialog();
            this.Hide();
        }

        // Hashes the password using SHA-256 and returns Base64 string
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(sha.ComputeHash(bytes)); // Convert hash bytes to string
            }
        }

        // Sends email to user either with a verification code or confirmation
        private void SendConfirmationEmail(string recipientEmail, string code = null)
        {
            string senderEmail = "bryandelapaz66850@gmail.com"; // Sender Gmail
            string senderPassword = "lyui gelf lhxq flta";       // Gmail app password

            // Determine subject and message based on whether a code was provided
            string subject = code == null ? "Account Registration Confirmation" : "Your Verification Code";
            string body = code == null
                ? "Thank you for registering. Your account has been successfully created!"
                : $"Your verification code is: {code}";

            try
            {
                // Setup Gmail SMTP server
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true; // Use SSL for security
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword); // Login

                    using (var message = new MailMessage(senderEmail, recipientEmail, subject, body))
                    {
                        smtp.Send(message); // Send email
                    }
                }
            }
            catch (Exception ex)
            {
                // Show warning if sending email fails
                MessageBox.Show("Email sending failed: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Checks if email format is valid using MailAddress class
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Enables/disables sign-up button and sets its label text
        private void SetSignupButtonState(bool enabled, string text = "Sign up")
        {
            btnSignup.Enabled = enabled;
            btnSignup.Text = text;
        }

        // Enables/disables verification code button and sets label text
        private void SetCodeButtonState(bool enabled, string text = "Send Code")
        {
            btnCodeVerification1.Enabled = enabled;
            btnCodeVerification1.Text = text;
        }

        // Show a warning message and re-enable the sign-up button
        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SetSignupButtonState(true);
        }

        // Show an error message and re-enable the sign-up button
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            SetSignupButtonState(true);
        }

        // Restricts code input textbox to digits only (e.g. for verification code)
        private void tbxCode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits or backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent input
            }
        }
    }
}
