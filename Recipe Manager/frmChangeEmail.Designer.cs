namespace Recipe_Manager
{
    partial class frmChangeEmail
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
            this.btnSendCode = new Guna.UI2.WinForms.Guna2Button();
            this.txtCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnUpdateEmail = new Guna.UI2.WinForms.Guna2Button();
            this.lblSignintext2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnBack2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnSendCode
            // 
            this.btnSendCode.Animated = true;
            this.btnSendCode.BackColor = System.Drawing.Color.Transparent;
            this.btnSendCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSendCode.BorderColor = System.Drawing.Color.Transparent;
            this.btnSendCode.BorderRadius = 17;
            this.btnSendCode.CheckedState.Parent = this.btnSendCode;
            this.btnSendCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendCode.CustomImages.Parent = this.btnSendCode;
            this.btnSendCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.btnSendCode.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendCode.ForeColor = System.Drawing.Color.White;
            this.btnSendCode.HoverState.Parent = this.btnSendCode;
            this.btnSendCode.Location = new System.Drawing.Point(219, 206);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.ShadowDecoration.Parent = this.btnSendCode;
            this.btnSendCode.Size = new System.Drawing.Size(94, 37);
            this.btnSendCode.TabIndex = 43;
            this.btnSendCode.Text = " Send code";
            this.btnSendCode.Click += new System.EventHandler(this.btnSendCode_Click);
            // 
            // txtCode
            // 
            this.txtCode.Animated = true;
            this.txtCode.BorderRadius = 17;
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.DefaultText = "";
            this.txtCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCode.DisabledState.Parent = this.txtCode;
            this.txtCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCode.FocusedState.Parent = this.txtCode;
            this.txtCode.Font = new System.Drawing.Font("Poppins", 9F);
            this.txtCode.ForeColor = System.Drawing.Color.Black;
            this.txtCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCode.HoverState.Parent = this.txtCode;
            this.txtCode.Location = new System.Drawing.Point(82, 206);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.PlaceholderText = "";
            this.txtCode.SelectedText = "";
            this.txtCode.ShadowDecoration.Parent = this.txtCode;
            this.txtCode.Size = new System.Drawing.Size(131, 36);
            this.txtCode.TabIndex = 42;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(82, 175);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(115, 25);
            this.lblCode.TabIndex = 41;
            this.lblCode.Text = "Verification Code";
            // 
            // txtEmail
            // 
            this.txtEmail.Animated = true;
            this.txtEmail.BorderRadius = 17;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new System.Drawing.Point(82, 133);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(231, 36);
            this.txtEmail.TabIndex = 40;
            // 
            // lblEmail3
            // 
            this.lblEmail3.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail3.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail3.ForeColor = System.Drawing.Color.Black;
            this.lblEmail3.Location = new System.Drawing.Point(82, 102);
            this.lblEmail3.Name = "lblEmail3";
            this.lblEmail3.Size = new System.Drawing.Size(38, 25);
            this.lblEmail3.TabIndex = 39;
            this.lblEmail3.Text = "Email";
            // 
            // txtPassword
            // 
            this.txtPassword.Animated = true;
            this.txtPassword.BorderRadius = 17;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.Parent = this.txtPassword;
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.FocusedState.Parent = this.txtPassword;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.HoverState.Parent = this.txtPassword;
            this.txtPassword.Location = new System.Drawing.Point(82, 298);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.ShadowDecoration.Parent = this.txtPassword;
            this.txtPassword.Size = new System.Drawing.Size(231, 36);
            this.txtPassword.TabIndex = 44;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(82, 267);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(66, 25);
            this.guna2HtmlLabel1.TabIndex = 45;
            this.guna2HtmlLabel1.Text = "Password";
            // 
            // btnUpdateEmail
            // 
            this.btnUpdateEmail.Animated = true;
            this.btnUpdateEmail.AutoRoundedCorners = true;
            this.btnUpdateEmail.BorderColor = System.Drawing.Color.Empty;
            this.btnUpdateEmail.BorderRadius = 21;
            this.btnUpdateEmail.CheckedState.Parent = this.btnUpdateEmail;
            this.btnUpdateEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateEmail.CustomImages.Parent = this.btnUpdateEmail;
            this.btnUpdateEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.btnUpdateEmail.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmail.ForeColor = System.Drawing.Color.White;
            this.btnUpdateEmail.HoverState.Parent = this.btnUpdateEmail;
            this.btnUpdateEmail.Location = new System.Drawing.Point(114, 369);
            this.btnUpdateEmail.Name = "btnUpdateEmail";
            this.btnUpdateEmail.ShadowDecoration.Parent = this.btnUpdateEmail;
            this.btnUpdateEmail.Size = new System.Drawing.Size(180, 45);
            this.btnUpdateEmail.TabIndex = 46;
            this.btnUpdateEmail.Text = "Confirm";
            this.btnUpdateEmail.Click += new System.EventHandler(this.btnUpdateEmail_Click);
            // 
            // lblSignintext2
            // 
            this.lblSignintext2.BackColor = System.Drawing.Color.Transparent;
            this.lblSignintext2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignintext2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.lblSignintext2.Location = new System.Drawing.Point(133, 28);
            this.lblSignintext2.Name = "lblSignintext2";
            this.lblSignintext2.Size = new System.Drawing.Size(134, 50);
            this.lblSignintext2.TabIndex = 47;
            this.lblSignintext2.Text = "Recovery";
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
            this.btnBack2.TabIndex = 48;
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
            this.btnExit.Location = new System.Drawing.Point(343, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedColor = System.Drawing.Color.White;
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(35, 32);
            this.btnExit.TabIndex = 49;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmChangeEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(390, 496);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBack2);
            this.Controls.Add(this.lblSignintext2);
            this.Controls.Add(this.btnUpdateEmail);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnSendCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChangeEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmChangeEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSendCode;
        private Guna.UI2.WinForms.Guna2TextBox txtCode;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCode;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail3;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnUpdateEmail;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSignintext2;
        private Guna.UI2.WinForms.Guna2Button btnBack2;
        private Guna.UI2.WinForms.Guna2Button btnExit;
    }
}