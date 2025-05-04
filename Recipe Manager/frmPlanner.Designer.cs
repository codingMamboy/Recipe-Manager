namespace Recipe_Manager
{
    partial class frmPlanner
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
            this.dtpPlanDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnWelcome = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecipe = new Guna.UI2.WinForms.Guna2Button();
            this.btnPlanner = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.lblDIsh = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboRecipes = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtRecipeNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flowRecipeMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUploadRecipe = new Guna.UI2.WinForms.Guna2Button();
            this.lblCourse = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCourse = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpPlanDate
            // 
            this.dtpPlanDate.Animated = true;
            this.dtpPlanDate.AutoRoundedCorners = true;
            this.dtpPlanDate.BorderRadius = 17;
            this.dtpPlanDate.CheckedState.Parent = this.dtpPlanDate;
            this.dtpPlanDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.dtpPlanDate.Font = new System.Drawing.Font("Poppins", 9.75F);
            this.dtpPlanDate.ForeColor = System.Drawing.SystemColors.Window;
            this.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpPlanDate.HoverState.Parent = this.dtpPlanDate;
            this.dtpPlanDate.Location = new System.Drawing.Point(288, 76);
            this.dtpPlanDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPlanDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPlanDate.Name = "dtpPlanDate";
            this.dtpPlanDate.ShadowDecoration.Parent = this.dtpPlanDate;
            this.dtpPlanDate.Size = new System.Drawing.Size(200, 36);
            this.dtpPlanDate.TabIndex = 1;
            this.dtpPlanDate.Value = new System.DateTime(2025, 5, 4, 11, 8, 13, 982);
            this.dtpPlanDate.ValueChanged += new System.EventHandler(this.dtpPlanDate_ValueChanged);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.guna2Panel1.Controls.Add(this.btnWelcome);
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
            this.guna2Panel1.TabIndex = 2;
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
            this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
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
            this.btnPlanner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnPlanner.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPlanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.btnPlanner.HoverState.Parent = this.btnPlanner;
            this.btnPlanner.Image = global::Recipe_Manager.Properties.Resources._6599587_course_e_learning_education_learning_online_icon;
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
            this.btnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.btnHome.Font = new System.Drawing.Font("Poppins", 10F);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.btnHome.HoverState.Parent = this.btnHome;
            this.btnHome.Image = global::Recipe_Manager.Properties.Resources._3669170_home_ic_icon;
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
            // lblDIsh
            // 
            this.lblDIsh.BackColor = System.Drawing.Color.Transparent;
            this.lblDIsh.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDIsh.ForeColor = System.Drawing.Color.Black;
            this.lblDIsh.Location = new System.Drawing.Point(288, 45);
            this.lblDIsh.Name = "lblDIsh";
            this.lblDIsh.Size = new System.Drawing.Size(77, 25);
            this.lblDIsh.TabIndex = 17;
            this.lblDIsh.Text = "Select Date";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(526, 45);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(47, 25);
            this.guna2HtmlLabel2.TabIndex = 23;
            this.guna2HtmlLabel2.Text = "Recipe";
            // 
            // cboRecipes
            // 
            this.cboRecipes.AutoRoundedCorners = true;
            this.cboRecipes.BackColor = System.Drawing.Color.Transparent;
            this.cboRecipes.BorderRadius = 17;
            this.cboRecipes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRecipes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecipes.FocusedColor = System.Drawing.Color.Empty;
            this.cboRecipes.FocusedState.Parent = this.cboRecipes;
            this.cboRecipes.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRecipes.ForeColor = System.Drawing.Color.Black;
            this.cboRecipes.FormattingEnabled = true;
            this.cboRecipes.HoverState.Parent = this.cboRecipes;
            this.cboRecipes.ItemHeight = 30;
            this.cboRecipes.Items.AddRange(new object[] {
            "Salt  ",
            "Pepper  ",
            "Garlic  ",
            "Onion  ",
            "Tomato  ",
            "Olive Oil  ",
            "Butter  ",
            "Sugar  ",
            "Eggs  ",
            "Flour  ",
            "Milk  ",
            "Cheese  ",
            "Basil  ",
            "Oregano  ",
            "Chicken  ",
            "Beef  ",
            "Pork  ",
            "Fish  ",
            "Soy Sauce  ",
            "Vinegar  ",
            "Paprika  ",
            "Cumin  ",
            "Coriander  ",
            "Ginger  ",
            "Thyme  ",
            "Parsley  ",
            "Celery  ",
            "Carrot  ",
            "Potato  ",
            "Bell Pepper  ",
            "Chili Powder  ",
            "Cinnamon  ",
            "Nutmeg  ",
            "Cloves  ",
            "Bay Leaf  ",
            "Mustard  ",
            "Mayonnaise  ",
            "Ketchup  ",
            "Worcestershire Sauce  ",
            "Lemon Juice  ",
            "Lime  ",
            "Spinach  ",
            "Broccoli  ",
            "Cauliflower  ",
            "Zucchini  ",
            "Cucumber  ",
            "Lettuce  ",
            "Green Beans  ",
            "Peas  ",
            "Corn  ",
            "Rice  ",
            "Pasta  ",
            "Bread  ",
            "Yeast  ",
            "Baking Powder  ",
            "Baking Soda  ",
            "Vanilla Extract  ",
            "Honey  ",
            "Maple Syrup  ",
            "Brown Sugar  ",
            "Ground Beef  ",
            "Ground Pork  ",
            "Ground Chicken  ",
            "Shrimp  ",
            "Crab  ",
            "Squid  ",
            "Tuna  ",
            "Salmon  ",
            "Tilapia  ",
            "Mussels  ",
            "Tofu  ",
            "Tempeh  ",
            "Chickpeas  ",
            "Lentils  ",
            "Kidney Beans  ",
            "Black Beans  ",
            "White Beans  ",
            "Red Lentils  ",
            "Green Lentils  ",
            "Mung Beans  ",
            "Coconut Milk  ",
            "Evaporated Milk  ",
            "Condensed Milk  ",
            "Cream Cheese  ",
            "Sour Cream  ",
            "Heavy Cream  ",
            "Mozzarella  ",
            "Cheddar  ",
            "Parmesan  ",
            "Feta  ",
            "Romaine Lettuce  ",
            "Iceberg Lettuce  ",
            "Arugula  ",
            "Kale  ",
            "Swiss Chard  ",
            "Leeks  ",
            "Shallots  ",
            "Scallions  ",
            "Chives  ",
            "Red Onion  ",
            "Green Onion  ",
            "Jalapeño  ",
            "Habanero  ",
            "Serrano Pepper  ",
            "Sweet Potato  ",
            "Yam  ",
            "Eggplant  ",
            "Okra  ",
            "Asparagus  ",
            "Artichoke  ",
            "Radish  ",
            "Beetroot  ",
            "Turnip  ",
            "Rutabaga  ",
            "Butternut Squash  ",
            "Acorn Squash  ",
            "Pumpkin  ",
            "Avocado  ",
            "Pineapple  ",
            "Apple  ",
            "Banana  ",
            "Orange  ",
            "Lemon  ",
            "Lime  ",
            "Grapes  ",
            "Watermelon  ",
            "Melon  ",
            "Strawberry  ",
            "Blueberry  ",
            "Raspberry  ",
            "Coconut  ",
            "Mango  ",
            "Papaya  ",
            "Guava  ",
            "Lychee  ",
            "Passion Fruit  ",
            "Pomegranate  ",
            "Kiwi  ",
            "Peach  ",
            "Plum  ",
            "Apricot  ",
            "Nectarine  ",
            "Date  ",
            "Fig  ",
            "Raisins  ",
            "Cranberries  ",
            "Walnuts  ",
            "Almonds  ",
            "Cashews  ",
            "Peanuts  ",
            "Hazelnuts  ",
            "Pistachios  ",
            "Pecans  ",
            "Sunflower Seeds  ",
            "Chia Seeds  ",
            "Flaxseeds  ",
            "Sesame Seeds  ",
            "Oats  ",
            "Barley  ",
            "Quinoa  ",
            "Polenta  ",
            "Couscous  ",
            "Bulgur  ",
            "Tapioca  ",
            "Cornstarch  ",
            "Arrowroot  ",
            "Agar-Agar  ",
            "Gelatin  ",
            "Nori  ",
            "Miso  ",
            "Tahini  ",
            "Peanut Butter  ",
            "Soy Milk  ",
            "Almond Milk  ",
            "Oat Milk  ",
            "Rice Milk  ",
            "Apple Cider Vinegar  ",
            "Balsamic Vinegar  ",
            "Red Wine Vinegar  ",
            "White Vinegar  ",
            "Green Curry Paste  ",
            "Red Curry Paste  ",
            "Yellow Curry Paste  ",
            "Sriracha  ",
            "Chili Garlic Sauce  ",
            "Hoisin Sauce  ",
            "Oyster Sauce  ",
            "Fish Sauce  ",
            "Teriyaki Sauce  ",
            "BBQ Sauce  ",
            "Breadcrumbs  ",
            "Croutons  ",
            "Pancetta  ",
            "Bacon  ",
            "Sausage  ",
            "Ham  ",
            "Chorizo  ",
            "Salami  ",
            "Turkey  ",
            "Duck  ",
            "Lamb  ",
            "Veal  ",
            "Game Meat  ",
            "Anchovy  ",
            "Sardines  ",
            "Clams  ",
            "Scallops  ",
            "Lobster  ",
            "Seaweed  ",
            "Wasabi  "});
            this.cboRecipes.ItemsAppearance.Parent = this.cboRecipes;
            this.cboRecipes.Location = new System.Drawing.Point(526, 76);
            this.cboRecipes.Name = "cboRecipes";
            this.cboRecipes.ShadowDecoration.Parent = this.cboRecipes;
            this.cboRecipes.Size = new System.Drawing.Size(155, 36);
            this.cboRecipes.TabIndex = 24;
            this.cboRecipes.SelectedIndexChanged += new System.EventHandler(this.cboRecipes_SelectedIndexChanged);
            // 
            // txtRecipeNotes
            // 
            this.txtRecipeNotes.AcceptsReturn = true;
            this.txtRecipeNotes.Animated = true;
            this.txtRecipeNotes.AutoScroll = true;
            this.txtRecipeNotes.BorderRadius = 10;
            this.txtRecipeNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRecipeNotes.DefaultText = "";
            this.txtRecipeNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRecipeNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRecipeNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRecipeNotes.DisabledState.Parent = this.txtRecipeNotes;
            this.txtRecipeNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRecipeNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRecipeNotes.FocusedState.Parent = this.txtRecipeNotes;
            this.txtRecipeNotes.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipeNotes.ForeColor = System.Drawing.Color.Black;
            this.txtRecipeNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRecipeNotes.HoverState.Parent = this.txtRecipeNotes;
            this.txtRecipeNotes.Location = new System.Drawing.Point(726, 76);
            this.txtRecipeNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRecipeNotes.Multiline = true;
            this.txtRecipeNotes.Name = "txtRecipeNotes";
            this.txtRecipeNotes.PasswordChar = '\0';
            this.txtRecipeNotes.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtRecipeNotes.PlaceholderText = "";
            this.txtRecipeNotes.SelectedText = "";
            this.txtRecipeNotes.ShadowDecoration.Parent = this.txtRecipeNotes;
            this.txtRecipeNotes.Size = new System.Drawing.Size(287, 106);
            this.txtRecipeNotes.TabIndex = 26;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(726, 45);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(88, 25);
            this.guna2HtmlLabel1.TabIndex = 27;
            this.guna2HtmlLabel1.Text = "Recipe Notes";
            // 
            // flowRecipeMenu
            // 
            this.flowRecipeMenu.AutoScroll = true;
            this.flowRecipeMenu.BackColor = System.Drawing.Color.White;
            this.flowRecipeMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowRecipeMenu.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowRecipeMenu.ForeColor = System.Drawing.SystemColors.Control;
            this.flowRecipeMenu.Location = new System.Drawing.Point(288, 233);
            this.flowRecipeMenu.Name = "flowRecipeMenu";
            this.flowRecipeMenu.Size = new System.Drawing.Size(725, 304);
            this.flowRecipeMenu.TabIndex = 28;
            // 
            // btnUploadRecipe
            // 
            this.btnUploadRecipe.Animated = true;
            this.btnUploadRecipe.AutoRoundedCorners = true;
            this.btnUploadRecipe.BorderColor = System.Drawing.Color.Empty;
            this.btnUploadRecipe.BorderRadius = 17;
            this.btnUploadRecipe.CheckedState.Parent = this.btnUploadRecipe;
            this.btnUploadRecipe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadRecipe.CustomImages.Parent = this.btnUploadRecipe;
            this.btnUploadRecipe.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.btnUploadRecipe.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadRecipe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnUploadRecipe.HoverState.Parent = this.btnUploadRecipe;
            this.btnUploadRecipe.Location = new System.Drawing.Point(288, 146);
            this.btnUploadRecipe.Name = "btnUploadRecipe";
            this.btnUploadRecipe.ShadowDecoration.Parent = this.btnUploadRecipe;
            this.btnUploadRecipe.Size = new System.Drawing.Size(145, 36);
            this.btnUploadRecipe.TabIndex = 35;
            this.btnUploadRecipe.Text = "Add recipe";
            this.btnUploadRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // lblCourse
            // 
            this.lblCourse.BackColor = System.Drawing.Color.Transparent;
            this.lblCourse.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.Black;
            this.lblCourse.Location = new System.Drawing.Point(526, 118);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(56, 25);
            this.lblCourse.TabIndex = 37;
            this.lblCourse.Text = "Courses";
            // 
            // txtCourse
            // 
            this.txtCourse.AutoRoundedCorners = true;
            this.txtCourse.BorderRadius = 18;
            this.txtCourse.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCourse.DefaultText = "";
            this.txtCourse.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCourse.DisabledState.Parent = this.txtCourse;
            this.txtCourse.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCourse.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCourse.FocusedState.Parent = this.txtCourse;
            this.txtCourse.Font = new System.Drawing.Font("Poppins", 9.75F);
            this.txtCourse.ForeColor = System.Drawing.Color.Black;
            this.txtCourse.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCourse.HoverState.Parent = this.txtCourse;
            this.txtCourse.Location = new System.Drawing.Point(526, 151);
            this.txtCourse.Margin = new System.Windows.Forms.Padding(5);
            this.txtCourse.Name = "txtCourse";
            this.txtCourse.PasswordChar = '\0';
            this.txtCourse.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCourse.PlaceholderText = "";
            this.txtCourse.ReadOnly = true;
            this.txtCourse.SelectedText = "";
            this.txtCourse.ShadowDecoration.Parent = this.txtCourse;
            this.txtCourse.Size = new System.Drawing.Size(155, 38);
            this.txtCourse.TabIndex = 38;
            // 
            // frmPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1072, 594);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.btnUploadRecipe);
            this.Controls.Add(this.flowRecipeMenu);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.txtRecipeNotes);
            this.Controls.Add(this.cboRecipes);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.lblDIsh);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dtpPlanDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPlanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPlanner";
            this.Load += new System.EventHandler(this.frmPlanner_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpPlanDate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnWelcome;
        private Guna.UI2.WinForms.Guna2Button btnRecipe;
        private Guna.UI2.WinForms.Guna2Button btnPlanner;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDIsh;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cboRecipes;
        private Guna.UI2.WinForms.Guna2TextBox txtRecipeNotes;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowRecipeMenu;
        private Guna.UI2.WinForms.Guna2Button btnUploadRecipe;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCourse;
        private Guna.UI2.WinForms.Guna2TextBox txtCourse;
    }
}