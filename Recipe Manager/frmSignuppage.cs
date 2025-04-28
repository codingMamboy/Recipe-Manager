using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Recipe_Manager
{
    public partial class frmSignuppage : Form
    {
        private string connectionString = "server=localhost;uid=root;pwd=12345;database=recipe_managerv2";
        private MySqlConnection conn;
        private string verificationCode;

        public frmSignuppage()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void frmSignuppage_Load(object sender, EventArgs e)
        {
            // Form load logic (if needed)
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            new frmLoginpage().Show();
            this.Hide();
        }

        private void tbxPwd2_TextChanged(object sender, EventArgs e)
        {
            tbxPwd2.UseSystemPasswordChar = true;
        }

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd.UseSystemPasswordChar = true;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

            btnSignup.Text = "Loading...";
            btnSignup.Enabled = false;

            string username = tbxUsername2.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string password = tbxPwd2.Text.Trim();
            string confirmPwd = tbxConfirmpwd.Text.Trim();
            string codeInput = tbxCode2.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPwd) ||
                string.IsNullOrEmpty(codeInput))
            {
                MessageBox.Show("Please fill all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnSignup.Text = "Sign up";
                btnSignup.Enabled = true;

                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnSignup.Text = "Sign up";
                btnSignup.Enabled = true;

                return;
            }

            if (password != confirmPwd)
            {
                MessageBox.Show("Passwords do not match.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnSignup.Text = "Sign up";
                btnSignup.Enabled = true;

                return;
            }

            if (codeInput != verificationCode)
            {
                MessageBox.Show("Incorrect verification code.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSignup.Text = "Sign up";
                btnSignup.Enabled = true;

                return;
            }

            try
            {
                conn.Open();

                // Check if username or email already exists
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    checkCmd.Parameters.AddWithValue("@email", email);

                    int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (userCount > 0)
                    {
                        MessageBox.Show("Username or Email already taken.", "Sign-Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnSignup.Text = "Sign up";
                        btnSignup.Enabled = true;

                        return;
                    }
                }

                // Hash the password (SHA256 only, no salt)
                string passwordHash = HashPassword(password);

                // Insert the new user
                string insertQuery = "INSERT INTO users (username, email, password_hash) VALUES (@username, @email, @password_hash)";
                using (var insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@email", email);
                    insertCmd.Parameters.AddWithValue("@password_hash", passwordHash);

                    int result = insertCmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SendConfirmationEmail(email); // optional final confirmation
                        new frmLoginpage().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sign-up failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnSignup.Text = "Sign up";
                        btnSignup.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSignup.Text = "Sign up";
                btnSignup.Enabled = true;
            }
            finally
            {
                conn.Close();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void SendConfirmationEmail(string recipientEmail, string code = null)
        {
            string senderEmail = "bryandelapaz66850@gmail.com";
            string senderPassword = "lyui gelf lhxq flta"; // App password

            string subject = code == null
                ? "Account Registration Confirmation"
                : "Your Verification Code";

            string body = code == null
                ? "Thank you for registering. Your account has been successfully created!"
                : $"Your verification code is: {code}";

            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress(senderEmail);
                        mail.To.Add(recipientEmail);
                        mail.Subject = subject;
                        mail.Body = body;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCodeVerification1_Click(object sender, EventArgs e)
        {
            btnCodeVerification1.Text = "Sending";
            btnCodeVerification1.Enabled = false;

            string email = tbxEmail.Text.Trim();
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnCodeVerification1.Text = "Send Code";
                btnCodeVerification1.Enabled = true;

                return;
            }


            verificationCode = new Random().Next(100000, 999999).ToString();
            SendConfirmationEmail(email, verificationCode);
            MessageBox.Show("Verification code sent. Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tbxEmail.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLoginpage loginpage = new frmLoginpage();
            this.Hide();
            loginpage.ShowDialog();
        }
    }
}
