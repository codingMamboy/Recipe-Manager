using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Recipe_Manager
{
    public partial class frmForgotpwd : Form
    {
        string connectionString = "server = localhost; uid = root; pwd = 12345; database = login";
        MySqlConnection conn;
        private string verificationCode;

        public frmForgotpwd()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {

           
            frmLoginpage frm = new frmLoginpage();
            frm.Show();
            this.Close();

        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void tbxNewpwd_TextChanged(object sender, EventArgs e)
        {
            tbxNewpwd.UseSystemPasswordChar = true;
        }

        private void tbxConfirmpwd_TextChanged(object sender, EventArgs e)
        {
            tbxConfirmpwd2.UseSystemPasswordChar = true;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSignintext2_Click(object sender, EventArgs e)
        {

        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string codeInput = tbxCode.Text.Trim();
            string newPassword = tbxNewpwd.Text.Trim();
            string confirmPwd = tbxConfirmpwd2.Text.Trim();

            if (string.IsNullOrEmpty(codeInput) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("Please fill all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (codeInput != verificationCode)
            {
                MessageBox.Show("Incorrect verification code. Please try again.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPwd)
            {
                MessageBox.Show("Your passwords do not match. Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string salt = Guid.NewGuid().ToString();
                string passwordHash = HashPassword(newPassword, salt);

                // Update the password in the database
                conn.Open();
                string updateQuery = "UPDATE users SET password_hash = @password_hash, password_salt = @password_salt WHERE email = @email";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@password_hash", passwordHash);
                updateCmd.Parameters.AddWithValue("@password_salt", salt);
                updateCmd.Parameters.AddWithValue("@email", tbxEmail3.Text.Trim());

                int result = updateCmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Password reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmLoginpage frm = new frmLoginpage();
                    frm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error resetting password. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Hash the password before storing it
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

        private void lblConfirmpwd_Click(object sender, EventArgs e)
        {
           
        }

        private void lblNewpwd_Click(object sender, EventArgs e)
        {
           
        }

        private void tbxCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCode_Click(object sender, EventArgs e)
        {
            
        }

        private void tbxEmail3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lblEmail3_Click(object sender, EventArgs e)
        {

        }

        private void frmForgotpwd_Load(object sender, EventArgs e)
        {

        }

        // Send verification code to the email
        private void btnCodeVerification2_Click(object sender, EventArgs e)
        {
            string email = tbxEmail3.Text.Trim();

            if (string.IsNullOrEmpty(email) || !email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@email", email);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount == 0)
                {
                    MessageBox.Show("Email not found. Please check the email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate a random verification code
                Random rnd = new Random();
                verificationCode = rnd.Next(100000, 999999).ToString();

                // Send verification code to the email
                SendVerificationCodeEmail(email);

                MessageBox.Show("Verification code sent. Please check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending code: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        // Send verification code via email
        private void SendVerificationCodeEmail(string recipientEmail)
        {
            string senderEmail = "bryandelapaz66850@gmail.com"; 
            string senderPassword = "lyui gelf lhxq flta"; 

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
                        mail.Subject = "Password Reset Verification Code";
                        mail.Body = $"Your password reset verification code is: {verificationCode}";

                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCodeVerification2_Click_1(object sender, EventArgs e)
        {
            string email = tbxEmail3.Text.Trim();

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
                        mail.Subject = "Your Verification Code for Recovery Password";
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
    }
}
