namespace Recipe_Manager
{
    partial class frmViewRecipe
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
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.pictureboxRecipe = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngredients = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtInstructions = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSlogan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRecipe)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeName.ForeColor = System.Drawing.Color.Black;
            this.lblRecipeName.Location = new System.Drawing.Point(12, 29);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(221, 51);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Recipe Name";
            // 
            // pictureboxRecipe
            // 
            this.pictureboxRecipe.BorderRadius = 10;
            this.pictureboxRecipe.Location = new System.Drawing.Point(21, 97);
            this.pictureboxRecipe.Name = "pictureboxRecipe";
            this.pictureboxRecipe.ShadowDecoration.Parent = this.pictureboxRecipe;
            this.pictureboxRecipe.Size = new System.Drawing.Size(339, 215);
            this.pictureboxRecipe.TabIndex = 4;
            this.pictureboxRecipe.TabStop = false;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.Black;
            this.lblCourse.Location = new System.Drawing.Point(16, 66);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(68, 28);
            this.lblCourse.TabIndex = 5;
            this.lblCourse.Text = "Course";
            // 
            // lblIngredients
            // 
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.ForeColor = System.Drawing.Color.Black;
            this.lblIngredients.Location = new System.Drawing.Point(12, 342);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(196, 51);
            this.lblIngredients.TabIndex = 6;
            this.lblIngredients.Text = "Ingredients";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(396, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 51);
            this.label1.TabIndex = 7;
            this.label1.Text = "DIRECTIONS";
            // 
            // txtIngredients
            // 
            this.txtIngredients.AutoScroll = true;
            this.txtIngredients.BorderRadius = 10;
            this.txtIngredients.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIngredients.DefaultText = "";
            this.txtIngredients.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIngredients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIngredients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIngredients.DisabledState.Parent = this.txtIngredients;
            this.txtIngredients.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIngredients.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIngredients.FocusedState.Parent = this.txtIngredients;
            this.txtIngredients.Font = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredients.ForeColor = System.Drawing.Color.Black;
            this.txtIngredients.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIngredients.HoverState.Parent = this.txtIngredients;
            this.txtIngredients.Location = new System.Drawing.Point(21, 396);
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.PasswordChar = '\0';
            this.txtIngredients.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtIngredients.PlaceholderText = "";
            this.txtIngredients.SelectedText = "";
            this.txtIngredients.ShadowDecoration.Parent = this.txtIngredients;
            this.txtIngredients.Size = new System.Drawing.Size(339, 221);
            this.txtIngredients.TabIndex = 2;
            // 
            // txtInstructions
            // 
            this.txtInstructions.AutoScroll = true;
            this.txtInstructions.BorderRadius = 10;
            this.txtInstructions.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstructions.DefaultText = "";
            this.txtInstructions.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInstructions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInstructions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInstructions.DisabledState.Parent = this.txtInstructions;
            this.txtInstructions.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInstructions.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInstructions.FocusedState.Parent = this.txtInstructions;
            this.txtInstructions.ForeColor = System.Drawing.Color.Black;
            this.txtInstructions.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInstructions.HoverState.Parent = this.txtInstructions;
            this.txtInstructions.Location = new System.Drawing.Point(405, 97);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.PasswordChar = '\0';
            this.txtInstructions.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtInstructions.PlaceholderText = "";
            this.txtInstructions.SelectedText = "";
            this.txtInstructions.ShadowDecoration.Parent = this.txtInstructions;
            this.txtInstructions.Size = new System.Drawing.Size(336, 520);
            this.txtInstructions.TabIndex = 3;
            this.txtInstructions.TextChanged += new System.EventHandler(this.txtInstructions_TextChanged);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.guna2Panel1.Controls.Add(this.lblSlogan);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.lblTitile);
            this.guna2Panel1.Location = new System.Drawing.Point(764, -2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(371, 653);
            this.guna2Panel1.TabIndex = 8;
            // 
            // lblSlogan
            // 
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Poppins Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblSlogan.Location = new System.Drawing.Point(101, 345);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(187, 24);
            this.lblSlogan.TabIndex = 5;
            this.lblSlogan.Text = "Your personal digital cookbook";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Recipe_Manager.Properties.Resources._753958_chefs_cook_food_hat_restaurant_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(31, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitile
            // 
            this.lblTitile.BackColor = System.Drawing.Color.Transparent;
            this.lblTitile.Font = new System.Drawing.Font("Poppins", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.lblTitile.Location = new System.Drawing.Point(97, 287);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(244, 86);
            this.lblTitile.TabIndex = 3;
            this.lblTitile.Text = "CookNest";
            // 
            // frmViewRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 649);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIngredients);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.pictureboxRecipe);
            this.Controls.Add(this.txtIngredients);
            this.Controls.Add(this.lblRecipeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewRecipe";
            this.Load += new System.EventHandler(this.frmViewRecipe_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRecipe)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecipeName;
        private Guna.UI2.WinForms.Guna2PictureBox pictureboxRecipe;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblIngredients;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtIngredients;
        private Guna.UI2.WinForms.Guna2TextBox txtInstructions;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSlogan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitile;
    }
}