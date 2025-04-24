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
        string connectionString = "server = localhost; uid = root; pwd = 12345; database = login";
        MySqlConnection conn;
        private string verificationCode;

        public frmSignuppage()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void frmSignuppage_Load(object sender, EventArgs e) { }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }
        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            frmLoginpage frm = new frmLoginpage();
            frm.Show();
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
       
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void btnSignup_Click(object sender, EventArgs e)
        {

            string username = tbxUsername2.Text.Trim();
            string password = tbxPwd2.Text.Trim();
            string confirmPwd = tbxConfirmpwd.Text.Trim();
            string email = tbxEmail.Text.Trim();
            string codeInput = tbxCode2.Text.Trim();


            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(confirmPwd) || string.IsNullOrEmpty(codeInput))

            {
                MessageBox.Show("Please fill all the inputs.", "No input detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPwd)
            {
                MessageBox.Show("Your password does not match, please try again", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (codeInput != verificationCode)
            {
                MessageBox.Show("Incorrect verification code.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);

                checkCmd.Parameters.AddWithValue("@username", username);
                checkCmd.Parameters.AddWithValue("@email", email);

                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Username or Email already taken.", "Sign-Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string salt = Guid.NewGuid().ToString();
                string passwordHash = HashPassword(password, salt);

                string insertQuery = "INSERT INTO users (username, email, password_hash, password_salt) VALUES (@username, @email, @password_hash, @password_salt)";
                
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@email", email); 
                insertCmd.Parameters.AddWithValue("@password_hash", passwordHash);
                insertCmd.Parameters.AddWithValue("@password_salt", salt);

                int result = insertCmd.ExecuteNonQuery();

                if (result > 0)
                {

                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SendConfirmationEmail(email);
                    frmLoginpage frm = new frmLoginpage();

                    frm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Sign-up failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string combined = password + salt;
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void SendConfirmationEmail(string recipientEmail)
        {
            string senderEmail = "bryandelapaz66850@gmail.com";
            string senderPassword = "lyui gelf lhxq flta"; // Use your Gmail App Password here

            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(senderEmail);
                        mail.To.Add(recipientEmail);
                        mail.Subject = "Account Registration Confirmation";
                        mail.Body = $"Thank you for registering. Your account has been successfully created!";

                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string email = tbxEmail.Text.Trim();

            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rnd = new Random();
            verificationCode = rnd.Next(100000, 999999).ToString();

            try
            {
                string senderEmail = "bryandelapaz66850@gmail.com";
                string senderPassword = "lyui gelf lhxq flta"; // Use your Gmail App Password here

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(senderEmail);
                        mail.To.Add(email);
                        mail.Subject = "Your Verification Code";
                        mail.Body = $"Your verification code is: {verificationCode}";

                        smtp.Send(mail);
                    }
                }

                MessageBox.Show("Verification code sent. Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending code: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxCode2_TextChanged(object sender, EventArgs e) { }

        private void tbxEmail_TextChanged(object sender, EventArgs e) { }
    }
}
