namespace Recipe_Manager
{
    partial class frmProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.lblSignintext2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEmail3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblUsername = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEmail = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblChangeEmail = new System.Windows.Forms.Label();
            this.lblEditUsername = new System.Windows.Forms.Label();
            this.btnBack2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AutoRoundedCorners = true;
            this.btnChangePassword.BorderRadius = 20;
            this.btnChangePassword.CheckedState.Parent = this.btnChangePassword;
            this.btnChangePassword.CustomImages.Parent = this.btnChangePassword;
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Poppins", 9.75F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.HoverState.Parent = this.btnChangePassword;
            this.btnChangePassword.Location = new System.Drawing.Point(134, 285);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ShadowDecoration.Parent = this.btnChangePassword;
            this.btnChangePassword.Size = new System.Drawing.Size(155, 43);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblSignintext2
            // 
            this.lblSignintext2.BackColor = System.Drawing.Color.Transparent;
            this.lblSignintext2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignintext2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.lblSignintext2.Location = new System.Drawing.Point(168, 33);
            this.lblSignintext2.Name = "lblSignintext2";
            this.lblSignintext2.Size = new System.Drawing.Size(92, 50);
            this.lblSignintext2.TabIndex = 16;
            this.lblSignintext2.Text = "Profile";
            // 
            // lblEmail3
            // 
            this.lblEmail3.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail3.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail3.ForeColor = System.Drawing.Color.Black;
            this.lblEmail3.Location = new System.Drawing.Point(73, 190);
            this.lblEmail3.Name = "lblEmail3";
            this.lblEmail3.Size = new System.Drawing.Size(48, 25);
            this.lblEmail3.TabIndex = 27;
            this.lblEmail3.Text = "Email : ";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(73, 113);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(80, 25);
            this.guna2HtmlLabel1.TabIndex = 28;
            this.guna2HtmlLabel1.Text = "Username :";
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(168, 113);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(70, 25);
            this.lblUsername.TabIndex = 29;
            this.lblUsername.Text = "Username";
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(168, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 25);
            this.lblEmail.TabIndex = 30;
            this.lblEmail.Text = "Username";
            // 
            // lblChangeEmail
            // 
            this.lblChangeEmail.AutoSize = true;
            this.lblChangeEmail.Font = new System.Drawing.Font("Poppins Light", 8.25F);
            this.lblChangeEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.lblChangeEmail.Location = new System.Drawing.Point(164, 218);
            this.lblChangeEmail.Name = "lblChangeEmail";
            this.lblChangeEmail.Size = new System.Drawing.Size(62, 19);
            this.lblChangeEmail.TabIndex = 33;
            this.lblChangeEmail.Text = "Edit Email";
            this.lblChangeEmail.Click += new System.EventHandler(this.lblChangeEmail_Click_1);
            // 
            // lblEditUsername
            // 
            this.lblEditUsername.AutoSize = true;
            this.lblEditUsername.Font = new System.Drawing.Font("Poppins Light", 8.25F);
            this.lblEditUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.lblEditUsername.Location = new System.Drawing.Point(164, 141);
            this.lblEditUsername.Name = "lblEditUsername";
            this.lblEditUsername.Size = new System.Drawing.Size(88, 19);
            this.lblEditUsername.TabIndex = 34;
            this.lblEditUsername.Text = "Edit Username";
            this.lblEditUsername.Click += new System.EventHandler(this.lblEditUsername_Click);
            // 
            // btnBack2
            // 
            this.btnBack2.Animated = true;
            this.btnBack2.BackgroundImage = global::Recipe_Manager.Properties.Resources.output_onlinetools__1_;
            this.btnBack2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack2.BorderColor = System.Drawing.Color.Transparent;
            this.btnBack2.CheckedState.Parent = this.btnBack2;
            this.btnBack2.CustomImages.Parent = this.btnBack2;
            this.btnBack2.FillColor = System.Drawing.Color.Empty;
            this.btnBack2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack2.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack2.HoverState.Parent = this.btnBack2;
            this.btnBack2.Location = new System.Drawing.Point(12, 12);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.PressedColor = System.Drawing.Color.White;
            this.btnBack2.ShadowDecoration.Parent = this.btnBack2;
            this.btnBack2.Size = new System.Drawing.Size(35, 32);
            this.btnBack2.TabIndex = 37;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnExit
            // 
            this.btnExit.Animated = true;
            this.btnExit.BackgroundImage = global::Recipe_Manager.Properties.Resources._9356052_logout_exit_icon__3_;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.CheckedState.Parent = this.btnExit;
            this.btnExit.CustomImages.Parent = this.btnExit;
            this.btnExit.FillColor = System.Drawing.Color.Empty;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.Location = new System.Drawing.Point(373, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedColor = System.Drawing.Color.White;
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(35, 32);
            this.btnExit.TabIndex = 38;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(420, 415);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBack2);
            this.Controls.Add(this.lblEditUsername);
            this.Controls.Add(this.lblChangeEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblEmail3);
            this.Controls.Add(this.lblSignintext2);
            this.Controls.Add(this.btnChangePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProfile";
            this.Load += new System.EventHandler(this.frmProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSignintext2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail;
        private System.Windows.Forms.Label lblChangeEmail;
        private System.Windows.Forms.Label lblEditUsername;
        private Guna.UI2.WinForms.Guna2Button btnBack2;
        private Guna.UI2.WinForms.Guna2Button btnExit;
    }
}