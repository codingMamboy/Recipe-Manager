namespace Recipe_Manager
{
    partial class frmLoginpage
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
            this.components = new System.ComponentModel.Container();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSlogan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSignintext = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbxUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbxPwd = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.lblHaveaccount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblForgotpwd = new System.Windows.Forms.Label();
            this.lblSignin = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.kryptonPalette1.PanelStyles.PanelAlternate.StateCommon.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette1.PanelStyles.PanelClient.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(125)))), ((int)(((byte)(68)))));
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(125)))), ((int)(((byte)(68)))));
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderThickness = 4;
            this.guna2Panel1.Controls.Add(this.lblSlogan);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.lblTitile);
            this.guna2Panel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Location = new System.Drawing.Point(-52, -5);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(565, 581);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // lblSlogan
            // 
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Poppins Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblSlogan.Location = new System.Drawing.Point(220, 285);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(187, 24);
            this.lblSlogan.TabIndex = 2;
            this.lblSlogan.Text = "Your personal digital cookbook";
            this.lblSlogan.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Recipe_Manager.Properties.Resources._753958_chefs_cook_food_hat_restaurant_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(150, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitile
            // 
            this.lblTitile.BackColor = System.Drawing.Color.Transparent;
            this.lblTitile.Font = new System.Drawing.Font("Poppins", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblTitile.Location = new System.Drawing.Point(216, 227);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(244, 86);
            this.lblTitile.TabIndex = 0;
            this.lblTitile.Text = "CookNest";
            // 
            // lblSignintext
            // 
            this.lblSignintext.BackColor = System.Drawing.Color.Transparent;
            this.lblSignintext.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignintext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(139)))));
            this.lblSignintext.Location = new System.Drawing.Point(653, 85);
            this.lblSignintext.Name = "lblSignintext";
            this.lblSignintext.Size = new System.Drawing.Size(254, 50);
            this.lblSignintext.TabIndex = 1;
            this.lblSignintext.Text = "Sign your account";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(139)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(666, 186);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(70, 25);
            this.guna2HtmlLabel4.TabIndex = 2;
            this.guna2HtmlLabel4.Text = "Username";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Animated = true;
            this.tbxUsername.BorderRadius = 17;
            this.tbxUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxUsername.DefaultText = "";
            this.tbxUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxUsername.DisabledState.Parent = this.tbxUsername;
            this.tbxUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxUsername.FocusedState.Parent = this.tbxUsername;
            this.tbxUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxUsername.HoverState.Parent = this.tbxUsername;
            this.tbxUsername.Location = new System.Drawing.Point(666, 217);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.PasswordChar = '\0';
            this.tbxUsername.PlaceholderText = "";
            this.tbxUsername.SelectedText = "";
            this.tbxUsername.ShadowDecoration.Parent = this.tbxUsername;
            this.tbxUsername.Size = new System.Drawing.Size(231, 36);
            this.tbxUsername.TabIndex = 3;
            this.tbxUsername.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(139)))));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(666, 259);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(66, 25);
            this.guna2HtmlLabel5.TabIndex = 4;
            this.guna2HtmlLabel5.Text = "Password";
            // 
            // tbxPwd
            // 
            this.tbxPwd.Animated = true;
            this.tbxPwd.BorderRadius = 17;
            this.tbxPwd.Cursor = System.Windows.Forms.Cursors.No;
            this.tbxPwd.DefaultText = "";
            this.tbxPwd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxPwd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxPwd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxPwd.DisabledState.Parent = this.tbxPwd;
            this.tbxPwd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxPwd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxPwd.FocusedState.Parent = this.tbxPwd;
            this.tbxPwd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxPwd.HoverState.Parent = this.tbxPwd;
            this.tbxPwd.Location = new System.Drawing.Point(666, 290);
            this.tbxPwd.Name = "tbxPwd";
            this.tbxPwd.PasswordChar = '\0';
            this.tbxPwd.PlaceholderText = "";
            this.tbxPwd.SelectedText = "";
            this.tbxPwd.ShadowDecoration.Parent = this.tbxPwd;
            this.tbxPwd.Size = new System.Drawing.Size(231, 36);
            this.tbxPwd.TabIndex = 5;
            this.tbxPwd.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BorderColor = System.Drawing.Color.Empty;
            this.btnLogin.BorderRadius = 17;
            this.btnLogin.CheckedState.Parent = this.btnLogin;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.CustomImages.Parent = this.btnLogin;
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(139)))));
            this.btnLogin.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.Parent = this.btnLogin;
            this.btnLogin.Location = new System.Drawing.Point(693, 359);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ShadowDecoration.Parent = this.btnLogin;
            this.btnLogin.Size = new System.Drawing.Size(180, 45);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Log in";
            // 
            // lblHaveaccount
            // 
            this.lblHaveaccount.BackColor = System.Drawing.Color.Transparent;
            this.lblHaveaccount.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaveaccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(139)))));
            this.lblHaveaccount.Location = new System.Drawing.Point(702, 410);
            this.lblHaveaccount.Name = "lblHaveaccount";
            this.lblHaveaccount.Size = new System.Drawing.Size(109, 21);
            this.lblHaveaccount.TabIndex = 8;
            this.lblHaveaccount.Text = "Don\'t have accout?";
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
            this.btnExit.Location = new System.Drawing.Point(966, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedColor = System.Drawing.Color.White;
            this.btnExit.ShadowDecoration.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(35, 32);
            this.btnExit.TabIndex = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblForgotpwd
            // 
            this.lblForgotpwd.AutoSize = true;
            this.lblForgotpwd.Font = new System.Drawing.Font("Poppins Light", 8.25F);
            this.lblForgotpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(125)))), ((int)(((byte)(68)))));
            this.lblForgotpwd.Location = new System.Drawing.Point(792, 329);
            this.lblForgotpwd.Name = "lblForgotpwd";
            this.lblForgotpwd.Size = new System.Drawing.Size(105, 19);
            this.lblForgotpwd.TabIndex = 11;
            this.lblForgotpwd.Text = "Forgot password?";
            this.lblForgotpwd.Click += new System.EventHandler(this.label1_Click);
            this.lblForgotpwd.Enter += new System.EventHandler(this.lblForgotpwd_Enter);
            // 
            // lblSignin
            // 
            this.lblSignin.AutoSize = true;
            this.lblSignin.Font = new System.Drawing.Font("Poppins Light", 8.25F);
            this.lblSignin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(125)))), ((int)(((byte)(68)))));
            this.lblSignin.Location = new System.Drawing.Point(817, 410);
            this.lblSignin.Name = "lblSignin";
            this.lblSignin.Size = new System.Drawing.Size(45, 19);
            this.lblSignin.TabIndex = 12;
            this.lblSignin.Text = "Sign in";
            this.lblSignin.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmLoginpage
            // 
            this.ClientSize = new System.Drawing.Size(1013, 574);
            this.Controls.Add(this.lblSignin);
            this.Controls.Add(this.lblForgotpwd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblHaveaccount);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxPwd);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.lblSignintext);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitile;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSlogan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSignintext;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox tbxUsername;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2TextBox tbxPwd;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHaveaccount;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label lblForgotpwd;
        private System.Windows.Forms.Label lblSignin;
    }
}

