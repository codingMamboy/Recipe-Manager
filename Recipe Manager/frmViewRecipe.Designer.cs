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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSlogan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitile = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtIngredients = new System.Windows.Forms.RichTextBox();
            this.txtInstructions = new System.Windows.Forms.RichTextBox();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRecipe)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.lblRecipeName.Location = new System.Drawing.Point(83, 53);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(159, 37);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Recipe Name";
            // 
            // pictureboxRecipe
            // 
            this.pictureboxRecipe.BorderRadius = 10;
            this.pictureboxRecipe.Location = new System.Drawing.Point(90, 111);
            this.pictureboxRecipe.Name = "pictureboxRecipe";
            this.pictureboxRecipe.ShadowDecoration.Parent = this.pictureboxRecipe;
            this.pictureboxRecipe.Size = new System.Drawing.Size(221, 199);
            this.pictureboxRecipe.TabIndex = 4;
            this.pictureboxRecipe.TabStop = false;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.lblCourse.Location = new System.Drawing.Point(86, 85);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(56, 23);
            this.lblCourse.TabIndex = 5;
            this.lblCourse.Text = "Course";
            // 
            // lblIngredients
            // 
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.lblIngredients.Location = new System.Drawing.Point(83, 323);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(141, 37);
            this.lblIngredients.TabIndex = 6;
            this.lblIngredients.Text = "Ingredients";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(114)))), ((int)(((byte)(20)))));
            this.label1.Location = new System.Drawing.Point(357, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "DIRECTIONS";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.guna2Panel1.Controls.Add(this.lblSlogan);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.lblTitile);
            this.guna2Panel1.Location = new System.Drawing.Point(709, -6);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(371, 662);
            this.guna2Panel1.TabIndex = 8;
            // 
            // lblSlogan
            // 
            this.lblSlogan.BackColor = System.Drawing.Color.Transparent;
            this.lblSlogan.Font = new System.Drawing.Font("Poppins Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblSlogan.Location = new System.Drawing.Point(102, 333);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(187, 24);
            this.lblSlogan.TabIndex = 5;
            this.lblSlogan.Text = "Your personal digital cookbook";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Recipe_Manager.Properties.Resources._753958_chefs_cook_food_hat_restaurant_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(32, 256);
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
            this.lblTitile.Location = new System.Drawing.Point(98, 275);
            this.lblTitile.Name = "lblTitile";
            this.lblTitile.Size = new System.Drawing.Size(244, 86);
            this.lblTitile.TabIndex = 3;
            this.lblTitile.Text = "CookNest";
            // 
            // txtIngredients
            // 
            this.txtIngredients.BackColor = System.Drawing.Color.White;
            this.txtIngredients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIngredients.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredients.Location = new System.Drawing.Point(90, 386);
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.ReadOnly = true;
            this.txtIngredients.Size = new System.Drawing.Size(221, 179);
            this.txtIngredients.TabIndex = 9;
            this.txtIngredients.Text = "";
            // 
            // txtInstructions
            // 
            this.txtInstructions.BackColor = System.Drawing.Color.White;
            this.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstructions.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstructions.Location = new System.Drawing.Point(364, 111);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.ReadOnly = true;
            this.txtInstructions.Size = new System.Drawing.Size(255, 444);
            this.txtInstructions.TabIndex = 10;
            this.txtInstructions.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BackgroundImage = global::Recipe_Manager.Properties.Resources.output_onlinetools__1_;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.BorderColor = System.Drawing.Color.Transparent;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.CustomImages.Parent = this.btnBack;
            this.btnBack.FillColor = System.Drawing.Color.Empty;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.Transparent;
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.PressedColor = System.Drawing.Color.White;
            this.btnBack.ShadowDecoration.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(35, 32);
            this.btnBack.TabIndex = 42;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmViewRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1076, 611);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.txtIngredients);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIngredients);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.pictureboxRecipe);
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
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSlogan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitile;
        private System.Windows.Forms.RichTextBox txtIngredients;
        private System.Windows.Forms.RichTextBox txtInstructions;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}