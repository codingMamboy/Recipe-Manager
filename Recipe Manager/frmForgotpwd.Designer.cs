﻿namespace Recipe_Manager
{
    partial class frmForgotpwd
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
            this.tbxCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbxNewpwd = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbxConfirmpwd2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCodeVerification2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit3 = new Guna.UI2.WinForms.Guna2Button();
            this.lblConfirmpwd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNewpwd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tbxEmail3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSignintext2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxCode
            // 
            this.tbxCode.Animated = true;
            this.tbxCode.BorderRadius = 17;
            this.tbxCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxCode.DefaultText = "";
            this.tbxCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxCode.DisabledState.Parent = this.tbxCode;
            this.tbxCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxCode.FocusedState.Parent = this.tbxCode;
            this.tbxCode.ForeColor = System.Drawing.Color.Black;
            this.tbxCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxCode.HoverState.Parent = this.tbxCode;
            this.tbxCode.Location = new System.Drawing.Point(55, 215);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.PasswordChar = '\0';
            this.tbxCode.PlaceholderText = "";
            this.tbxCode.SelectedText = "";
            this.tbxCode.ShadowDecoration.Parent = this.tbxCode;
            this.tbxCode.Size = new System.Drawing.Size(131, 36);
            this.tbxCode.TabIndex = 29;
            this.tbxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCode_KeyPress);
            // 
            // tbxNewpwd
            // 
            this.tbxNewpwd.Animated = true;
            this.tbxNewpwd.BorderRadius = 17;
            this.tbxNewpwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxNewpwd.DefaultText = "";
            this.tbxNewpwd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxNewpwd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxNewpwd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxNewpwd.DisabledState.Parent = this.tbxNewpwd;
            this.tbxNewpwd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxNewpwd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxNewpwd.FocusedState.Parent = this.tbxNewpwd;
            this.tbxNewpwd.ForeColor = System.Drawing.Color.Black;
            this.tbxNewpwd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxNewpwd.HoverState.Parent = this.tbxNewpwd;
            this.tbxNewpwd.Location = new System.Drawing.Point(55, 288);
            this.tbxNewpwd.Name = "tbxNewpwd";
            this.tbxNewpwd.PasswordChar = '\0';
            this.tbxNewpwd.PlaceholderText = "";
            this.tbxNewpwd.SelectedText = "";
            this.tbxNewpwd.ShadowDecoration.Parent = this.tbxNewpwd;
            this.tbxNewpwd.Size = new System.Drawing.Size(231, 36);
            this.tbxNewpwd.TabIndex = 31;
            this.tbxNewpwd.TextChanged += new System.EventHandler(this.tbxNewpwd_TextChanged);
            // 
            // tbxConfirmpwd2
            // 
            this.tbxConfirmpwd2.Animated = true;
            this.tbxConfirmpwd2.BorderRadius = 17;
            this.tbxConfirmpwd2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxConfirmpwd2.DefaultText = "";
            this.tbxConfirmpwd2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxConfirmpwd2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxConfirmpwd2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxConfirmpwd2.DisabledState.Parent = this.tbxConfirmpwd2;
            this.tbxConfirmpwd2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxConfirmpwd2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxConfirmpwd2.FocusedState.Parent = this.tbxConfirmpwd2;
            this.tbxConfirmpwd2.ForeColor = System.Drawing.Color.Black;
            this.tbxConfirmpwd2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxConfirmpwd2.HoverState.Parent = this.tbxConfirmpwd2;
            this.tbxConfirmpwd2.Location = new System.Drawing.Point(55, 361);
            this.tbxConfirmpwd2.Name = "tbxConfirmpwd2";
            this.tbxConfirmpwd2.PasswordChar = '\0';
            this.tbxConfirmpwd2.PlaceholderText = "";
            this.tbxConfirmpwd2.SelectedText = "";
            this.tbxConfirmpwd2.ShadowDecoration.Parent = this.tbxConfirmpwd2;
            this.tbxConfirmpwd2.Size = new System.Drawing.Size(231, 36);
            this.tbxConfirmpwd2.TabIndex = 32;
            this.tbxConfirmpwd2.TextChanged += new System.EventHandler(this.tbxConfirmpwd_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Animated = true;
            this.btnConfirm.AutoRoundedCorners = true;
            this.btnConfirm.BorderColor = System.Drawing.Color.Empty;
            this.btnConfirm.BorderRadius = 21;
            this.btnConfirm.CheckedState.Parent = this.btnConfirm;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.CustomImages.Parent = this.btnConfirm;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.btnConfirm.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.Parent = this.btnConfirm;
            this.btnConfirm.Location = new System.Drawing.Point(79, 435);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(180, 45);
            this.btnConfirm.TabIndex = 34;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.guna2Panel1.Controls.Add(this.btnCodeVerification2);
            this.guna2Panel1.Controls.Add(this.btnBack2);
            this.guna2Panel1.Controls.Add(this.btnExit3);
            this.guna2Panel1.Controls.Add(this.btnConfirm);
            this.guna2Panel1.Controls.Add(this.lblConfirmpwd);
            this.guna2Panel1.Controls.Add(this.tbxConfirmpwd2);
            this.guna2Panel1.Controls.Add(this.tbxNewpwd);
            this.guna2Panel1.Controls.Add(this.lblNewpwd);
            this.guna2Panel1.Controls.Add(this.tbxCode);
            this.guna2Panel1.Controls.Add(this.lblCode);
            this.guna2Panel1.Controls.Add(this.tbxEmail3);
            this.guna2Panel1.Controls.Add(this.lblEmail3);
            this.guna2Panel1.Controls.Add(this.lblSignintext2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(332, 522);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnCodeVerification2
            // 
            this.btnCodeVerification2.Animated = true;
            this.btnCodeVerification2.BackColor = System.Drawing.Color.Transparent;
            this.btnCodeVerification2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCodeVerification2.BorderColor = System.Drawing.Color.Transparent;
            this.btnCodeVerification2.BorderRadius = 17;
            this.btnCodeVerification2.CheckedState.Parent = this.btnCodeVerification2;
            this.btnCodeVerification2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodeVerification2.CustomImages.Parent = this.btnCodeVerification2;
            this.btnCodeVerification2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.btnCodeVerification2.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodeVerification2.ForeColor = System.Drawing.Color.White;
            this.btnCodeVerification2.HoverState.Parent = this.btnCodeVerification2;
            this.btnCodeVerification2.Location = new System.Drawing.Point(192, 215);
            this.btnCodeVerification2.Name = "btnCodeVerification2";
            this.btnCodeVerification2.ShadowDecoration.Parent = this.btnCodeVerification2;
            this.btnCodeVerification2.Size = new System.Drawing.Size(94, 37);
            this.btnCodeVerification2.TabIndex = 37;
            this.btnCodeVerification2.Text = " Send code";
            this.btnCodeVerification2.Click += new System.EventHandler(this.btnCodeVerification2_Click_1);
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
            this.btnBack2.TabIndex = 36;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnExit3
            // 
            this.btnExit3.Animated = true;
            this.btnExit3.BackgroundImage = global::Recipe_Manager.Properties.Resources._9356052_logout_exit_icon__3_;
            this.btnExit3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit3.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit3.CheckedState.Parent = this.btnExit3;
            this.btnExit3.CustomImages.Parent = this.btnExit3;
            this.btnExit3.FillColor = System.Drawing.Color.Empty;
            this.btnExit3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit3.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit3.HoverState.Parent = this.btnExit3;
            this.btnExit3.Location = new System.Drawing.Point(284, 12);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.PressedColor = System.Drawing.Color.White;
            this.btnExit3.ShadowDecoration.Parent = this.btnExit3;
            this.btnExit3.Size = new System.Drawing.Size(35, 32);
            this.btnExit3.TabIndex = 35;
            this.btnExit3.Click += new System.EventHandler(this.btnExit3_Click);
            // 
            // lblConfirmpwd
            // 
            this.lblConfirmpwd.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmpwd.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmpwd.ForeColor = System.Drawing.Color.Black;
            this.lblConfirmpwd.Location = new System.Drawing.Point(55, 330);
            this.lblConfirmpwd.Name = "lblConfirmpwd";
            this.lblConfirmpwd.Size = new System.Drawing.Size(121, 25);
            this.lblConfirmpwd.TabIndex = 33;
            this.lblConfirmpwd.Text = "Confirm Password";
            // 
            // lblNewpwd
            // 
            this.lblNewpwd.BackColor = System.Drawing.Color.Transparent;
            this.lblNewpwd.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewpwd.ForeColor = System.Drawing.Color.Black;
            this.lblNewpwd.Location = new System.Drawing.Point(55, 257);
            this.lblNewpwd.Name = "lblNewpwd";
            this.lblNewpwd.Size = new System.Drawing.Size(100, 25);
            this.lblNewpwd.TabIndex = 30;
            this.lblNewpwd.Text = "New password";
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(55, 184);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(115, 25);
            this.lblCode.TabIndex = 28;
            this.lblCode.Text = "Verification Code";
            // 
            // tbxEmail3
            // 
            this.tbxEmail3.Animated = true;
            this.tbxEmail3.BorderRadius = 17;
            this.tbxEmail3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxEmail3.DefaultText = "";
            this.tbxEmail3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxEmail3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxEmail3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxEmail3.DisabledState.Parent = this.tbxEmail3;
            this.tbxEmail3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxEmail3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxEmail3.FocusedState.Parent = this.tbxEmail3;
            this.tbxEmail3.ForeColor = System.Drawing.Color.Black;
            this.tbxEmail3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxEmail3.HoverState.Parent = this.tbxEmail3;
            this.tbxEmail3.Location = new System.Drawing.Point(55, 142);
            this.tbxEmail3.Name = "tbxEmail3";
            this.tbxEmail3.PasswordChar = '\0';
            this.tbxEmail3.PlaceholderText = "";
            this.tbxEmail3.SelectedText = "";
            this.tbxEmail3.ShadowDecoration.Parent = this.tbxEmail3;
            this.tbxEmail3.Size = new System.Drawing.Size(231, 36);
            this.tbxEmail3.TabIndex = 27;
            // 
            // lblEmail3
            // 
            this.lblEmail3.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail3.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail3.ForeColor = System.Drawing.Color.Black;
            this.lblEmail3.Location = new System.Drawing.Point(55, 111);
            this.lblEmail3.Name = "lblEmail3";
            this.lblEmail3.Size = new System.Drawing.Size(38, 25);
            this.lblEmail3.TabIndex = 26;
            this.lblEmail3.Text = "Email";
            // 
            // lblSignintext2
            // 
            this.lblSignintext2.BackColor = System.Drawing.Color.Transparent;
            this.lblSignintext2.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignintext2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.lblSignintext2.Location = new System.Drawing.Point(107, 49);
            this.lblSignintext2.Name = "lblSignintext2";
            this.lblSignintext2.Size = new System.Drawing.Size(134, 50);
            this.lblSignintext2.TabIndex = 15;
            this.lblSignintext2.Text = "Recovery";
            // 
            // frmForgotpwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 522);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmForgotpwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmForgotpwd";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox tbxCode;
        private Guna.UI2.WinForms.Guna2TextBox tbxNewpwd;
        private Guna.UI2.WinForms.Guna2TextBox tbxConfirmpwd2;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2Button btnExit3;
        private Guna.UI2.WinForms.Guna2Button btnBack2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblConfirmpwd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNewpwd;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCode;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSignintext2;
        private Guna.UI2.WinForms.Guna2TextBox tbxEmail3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEmail3;
        private Guna.UI2.WinForms.Guna2Button btnCodeVerification2;
    }
}