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
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemoveRecipe = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddRecipe = new Guna.UI2.WinForms.Guna2Button();
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
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
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
            // 
            // flowRecipeMenu
            // 
            this.flowRecipeMenu.AutoScroll = true;
            this.flowRecipeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(232)))), ((int)(((byte)(217)))));
            this.flowRecipeMenu.Location = new System.Drawing.Point(316, 140);
            this.flowRecipeMenu.Name = "flowRecipeMenu";
            this.flowRecipeMenu.Size = new System.Drawing.Size(672, 364);
            this.flowRecipeMenu.TabIndex = 11;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(316, 88);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(120, 36);
            this.guna2HtmlLabel1.TabIndex = 12;
            this.guna2HtmlLabel1.Text = "Your Recipe:";
            // 
            // txtSearchbar
            // 
            this.txtSearchbar.AutoRoundedCorners = true;
            this.txtSearchbar.BorderRadius = 14;
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
            this.txtSearchbar.Location = new System.Drawing.Point(812, 88);
            this.txtSearchbar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchbar.Name = "txtSearchbar";
            this.txtSearchbar.PasswordChar = '\0';
            this.txtSearchbar.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtSearchbar.PlaceholderText = "";
            this.txtSearchbar.SelectedText = "";
            this.txtSearchbar.ShadowDecoration.Parent = this.txtSearchbar;
            this.txtSearchbar.Size = new System.Drawing.Size(176, 31);
            this.txtSearchbar.TabIndex = 13;
            this.txtSearchbar.TextChanged += new System.EventHandler(this.txtSearchbar_TextChanged);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.BackgroundImage = global::Recipe_Manager.Properties.Resources._9356052_logout_exit_icon__3_;
            this.guna2Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2Button2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.Empty;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.Transparent;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(953, 12);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.PressedColor = System.Drawing.Color.White;
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(35, 32);
            this.guna2Button2.TabIndex = 16;
            // 
            // btnRemoveRecipe
            // 
            this.btnRemoveRecipe.Animated = true;
            this.btnRemoveRecipe.BackgroundImage = global::Recipe_Manager.Properties.Resources._9041687_button_minus_icon;
            this.btnRemoveRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoveRecipe.BorderColor = System.Drawing.Color.Transparent;
            this.btnRemoveRecipe.CheckedState.Parent = this.btnRemoveRecipe;
            this.btnRemoveRecipe.CustomImages.Parent = this.btnRemoveRecipe;
            this.btnRemoveRecipe.FillColor = System.Drawing.Color.Empty;
            this.btnRemoveRecipe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveRecipe.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemoveRecipe.HoverState.Parent = this.btnRemoveRecipe;
            this.btnRemoveRecipe.Location = new System.Drawing.Point(465, 92);
            this.btnRemoveRecipe.Name = "btnRemoveRecipe";
            this.btnRemoveRecipe.PressedColor = System.Drawing.Color.White;
            this.btnRemoveRecipe.ShadowDecoration.Parent = this.btnRemoveRecipe;
            this.btnRemoveRecipe.Size = new System.Drawing.Size(23, 28);
            this.btnRemoveRecipe.TabIndex = 15;
            this.btnRemoveRecipe.Click += new System.EventHandler(this.btnRemoveRecipe_Click);
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Animated = true;
            this.btnAddRecipe.BackgroundImage = global::Recipe_Manager.Properties.Resources._9041636_button_add_icon;
            this.btnAddRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddRecipe.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddRecipe.CheckedState.Parent = this.btnAddRecipe;
            this.btnAddRecipe.CustomImages.Parent = this.btnAddRecipe;
            this.btnAddRecipe.FillColor = System.Drawing.Color.Empty;
            this.btnAddRecipe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddRecipe.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddRecipe.HoverState.Parent = this.btnAddRecipe;
            this.btnAddRecipe.Location = new System.Drawing.Point(439, 92);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.PressedColor = System.Drawing.Color.White;
            this.btnAddRecipe.ShadowDecoration.Parent = this.btnAddRecipe;
            this.btnAddRecipe.Size = new System.Drawing.Size(23, 28);
            this.btnAddRecipe.TabIndex = 14;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
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
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.btnHome.HoverState.Parent = this.btnHome;
            this.btnHome.Image = global::Recipe_Manager.Properties.Resources.output_onlinetools__4_1;
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
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1072, 594);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.btnRemoveRecipe);
            this.Controls.Add(this.btnAddRecipe);
            this.Controls.Add(this.flowRecipeMenu);
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
        private Guna.UI2.WinForms.Guna2Button btnAddRecipe;
        private Guna.UI2.WinForms.Guna2Button btnRemoveRecipe;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}