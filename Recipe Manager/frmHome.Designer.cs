namespace Recipe_Manager
{
    partial class frmHome
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowRecipeMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSearchbar = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnWelcome = new Guna.UI2.WinForms.Guna2Button();
            this.btnSetting = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecipe = new Guna.UI2.WinForms.Guna2Button();
            this.btnPlanner = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.guna2Panel1.Controls.Add(this.btnWelcome);
            this.guna2Panel1.Controls.Add(this.btnSetting);
            this.guna2Panel1.Controls.Add(this.btnRecipe);
            this.guna2Panel1.Controls.Add(this.btnPlanner);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.btnHome);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(229, 594);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(63, 39);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(138, 50);
            this.guna2HtmlLabel3.TabIndex = 6;
            this.guna2HtmlLabel3.Text = "CookNest";
            this.guna2HtmlLabel3.Click += new System.EventHandler(this.guna2HtmlLabel3_Click);
            // 
            // flowRecipeMenu
            // 
            this.flowRecipeMenu.AutoScroll = true;
            this.flowRecipeMenu.BackColor = System.Drawing.Color.Transparent;
            this.flowRecipeMenu.Location = new System.Drawing.Point(254, 98);
            this.flowRecipeMenu.Name = "flowRecipeMenu";
            this.flowRecipeMenu.Size = new System.Drawing.Size(806, 440);
            this.flowRecipeMenu.TabIndex = 11;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(254, 39);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(180, 53);
            this.guna2HtmlLabel1.TabIndex = 12;
            this.guna2HtmlLabel1.Text = "Your Recipe";
            this.guna2HtmlLabel1.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
            // 
            // txtSearchbar
            // 
            this.txtSearchbar.AutoRoundedCorners = true;
            this.txtSearchbar.BorderRadius = 17;
            this.txtSearchbar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchbar.DefaultText = "";
            this.txtSearchbar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchbar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchbar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchbar.DisabledState.Parent = this.txtSearchbar;
            this.txtSearchbar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchbar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchbar.FocusedState.Parent = this.txtSearchbar;
            this.txtSearchbar.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchbar.ForeColor = System.Drawing.Color.Black;
            this.txtSearchbar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchbar.HoverState.Parent = this.txtSearchbar;
            this.txtSearchbar.Location = new System.Drawing.Point(840, 48);
            this.txtSearchbar.Name = "txtSearchbar";
            this.txtSearchbar.PasswordChar = '\0';
            this.txtSearchbar.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtSearchbar.PlaceholderText = "";
            this.txtSearchbar.SelectedText = "";
            this.txtSearchbar.ShadowDecoration.Parent = this.txtSearchbar;
            this.txtSearchbar.Size = new System.Drawing.Size(200, 36);
            this.txtSearchbar.TabIndex = 13;
            this.txtSearchbar.TextChanged += new System.EventHandler(this.txtSearchbar_TextChanged);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(788, 55);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(48, 25);
            this.guna2HtmlLabel2.TabIndex = 14;
            this.guna2HtmlLabel2.Text = "Search";
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click_1);
            // 
            // btnWelcome
            // 
            this.btnWelcome.Animated = true;
            this.btnWelcome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWelcome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnWelcome.BorderRadius = 3;
            this.btnWelcome.BorderThickness = 1;
            this.btnWelcome.CheckedState.Parent = this.btnWelcome;
            this.btnWelcome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWelcome.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnWelcome.CustomImages.Parent = this.btnWelcome;
            this.btnWelcome.FillColor = System.Drawing.Color.Transparent;
            this.btnWelcome.Font = new System.Drawing.Font("Poppins", 10F);
            this.btnWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnWelcome.HoverState.Parent = this.btnWelcome;
            this.btnWelcome.Image = global::Recipe_Manager.Properties.Resources._7853767_kashifarif_user_profile_person_account_icon;
            this.btnWelcome.Location = new System.Drawing.Point(21, 540);
            this.btnWelcome.Name = "btnWelcome";
            this.btnWelcome.PressedColor = System.Drawing.Color.Transparent;
            this.btnWelcome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnWelcome.ShadowDecoration.Parent = this.btnWelcome;
            this.btnWelcome.Size = new System.Drawing.Size(180, 42);
            this.btnWelcome.TabIndex = 13;
            this.btnWelcome.Text = "Username";
            // 
            // btnSetting
            // 
            this.btnSetting.Animated = true;
            this.btnSetting.AutoRoundedCorners = true;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSetting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnSetting.BorderRadius = 20;
            this.btnSetting.CheckedState.Parent = this.btnSetting;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnSetting.CustomImages.Parent = this.btnSetting;
            this.btnSetting.FillColor = System.Drawing.Color.Transparent;
            this.btnSetting.Font = new System.Drawing.Font("Poppins", 10F);
            this.btnSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnSetting.HoverState.Parent = this.btnSetting;
            this.btnSetting.Image = global::Recipe_Manager.Properties.Resources._2849830_multimedia_options_setting_settings_gear_icon;
            this.btnSetting.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSetting.Location = new System.Drawing.Point(21, 312);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.PressedColor = System.Drawing.Color.Transparent;
            this.btnSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSetting.ShadowDecoration.Parent = this.btnSetting;
            this.btnSetting.Size = new System.Drawing.Size(180, 42);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "Setting";
            this.btnSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnRecipe
            // 
            this.btnRecipe.Animated = true;
            this.btnRecipe.AutoRoundedCorners = true;
            this.btnRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRecipe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnRecipe.BorderRadius = 20;
            this.btnRecipe.CheckedState.Parent = this.btnRecipe;
            this.btnRecipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecipe.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnRecipe.CustomImages.Parent = this.btnRecipe;
            this.btnRecipe.FillColor = System.Drawing.Color.Transparent;
            this.btnRecipe.Font = new System.Drawing.Font("Poppins", 10F);
            this.btnRecipe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnRecipe.HoverState.Parent = this.btnRecipe;
            this.btnRecipe.Image = global::Recipe_Manager.Properties.Resources._10772845_cook_book_recipe_food_and_icon;
            this.btnRecipe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnRecipe.Location = new System.Drawing.Point(21, 255);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.PressedColor = System.Drawing.Color.Transparent;
            this.btnRecipe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRecipe.ShadowDecoration.Parent = this.btnRecipe;
            this.btnRecipe.Size = new System.Drawing.Size(180, 42);
            this.btnRecipe.TabIndex = 10;
            this.btnRecipe.Text = "Recipe";
            this.btnRecipe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRecipe.Click += new System.EventHandler(this.btnRecipe_Click);
            // 
            // btnPlanner
            // 
            this.btnPlanner.Animated = true;
            this.btnPlanner.AutoRoundedCorners = true;
            this.btnPlanner.BackColor = System.Drawing.Color.Transparent;
            this.btnPlanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlanner.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnPlanner.BorderRadius = 20;
            this.btnPlanner.CheckedState.Parent = this.btnPlanner;
            this.btnPlanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlanner.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnPlanner.CustomImages.Parent = this.btnPlanner;
            this.btnPlanner.FillColor = System.Drawing.Color.Transparent;
            this.btnPlanner.Font = new System.Drawing.Font("Poppins", 10F);
            this.btnPlanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnPlanner.HoverState.Parent = this.btnPlanner;
            this.btnPlanner.Image = global::Recipe_Manager.Properties.Resources._7727575_planner_calendar_date_day_appointment_icon__1_;
            this.btnPlanner.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPlanner.Location = new System.Drawing.Point(21, 197);
            this.btnPlanner.Name = "btnPlanner";
            this.btnPlanner.PressedColor = System.Drawing.Color.Transparent;
            this.btnPlanner.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPlanner.ShadowDecoration.Parent = this.btnPlanner;
            this.btnPlanner.Size = new System.Drawing.Size(180, 42);
            this.btnPlanner.TabIndex = 9;
            this.btnPlanner.Text = "Planner";
            this.btnPlanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPlanner.Click += new System.EventHandler(this.btnPlanner_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BackgroundImage = global::Recipe_Manager.Properties.Resources._753958_chefs_cook_food_hat_restaurant_icon__3_;
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(74, 90);
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.Animated = true;
            this.btnHome.AutoRoundedCorners = true;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnHome.BorderRadius = 20;
            this.btnHome.CheckedState.Parent = this.btnHome;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnHome.CustomImages.Parent = this.btnHome;
            this.btnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnHome.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.HoverState.Parent = this.btnHome;
            this.btnHome.Image = global::Recipe_Manager.Properties.Resources.output_onlinetools__7_;
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnHome.Location = new System.Drawing.Point(21, 140);
            this.btnHome.Name = "btnHome";
            this.btnHome.PressedColor = System.Drawing.Color.Transparent;
            this.btnHome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHome.ShadowDecoration.Parent = this.btnHome;
            this.btnHome.Size = new System.Drawing.Size(180, 42);
            this.btnHome.TabIndex = 8;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1072, 594);
            this.Controls.Add(this.flowRecipeMenu);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.txtSearchbar);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnPlanner;
        private Guna.UI2.WinForms.Guna2Button btnSetting;
        private Guna.UI2.WinForms.Guna2Button btnRecipe;
        private Guna.UI2.WinForms.Guna2Button btnWelcome;
        private System.Windows.Forms.FlowLayoutPanel flowRecipeMenu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchbar;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}