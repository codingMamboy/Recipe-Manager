namespace Recipe_Manager
{
    partial class frmViewPlan
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
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblRecipeName = new System.Windows.Forms.Label();
            this.pictureboxRecipe = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnDeletePLam = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRecipe)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.lblCourse.Location = new System.Drawing.Point(53, 172);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(56, 23);
            this.lblCourse.TabIndex = 38;
            this.lblCourse.Text = "Course";
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.lblRecipeName.Location = new System.Drawing.Point(50, 140);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(159, 37);
            this.lblRecipeName.TabIndex = 37;
            this.lblRecipeName.Text = "Recipe Name";
            // 
            // pictureboxRecipe
            // 
            this.pictureboxRecipe.BorderRadius = 10;
            this.pictureboxRecipe.Location = new System.Drawing.Point(57, 198);
            this.pictureboxRecipe.Name = "pictureboxRecipe";
            this.pictureboxRecipe.ShadowDecoration.Parent = this.pictureboxRecipe;
            this.pictureboxRecipe.Size = new System.Drawing.Size(152, 136);
            this.pictureboxRecipe.TabIndex = 40;
            this.pictureboxRecipe.TabStop = false;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNotes.Location = new System.Drawing.Point(233, 198);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Size = new System.Drawing.Size(158, 136);
            this.txtNotes.TabIndex = 41;
            this.txtNotes.Text = "";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Poppins", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.lblDate.Location = new System.Drawing.Point(46, 47);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(112, 62);
            this.lblDate.TabIndex = 42;
            this.lblDate.Text = "Date";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Location = new System.Drawing.Point(541, -106);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(267, 587);
            this.guna2Panel1.TabIndex = 43;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(233)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(95, 287);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(138, 50);
            this.guna2HtmlLabel3.TabIndex = 8;
            this.guna2HtmlLabel3.Text = "CookNest";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BackgroundImage = global::Recipe_Manager.Properties.Resources._753958_chefs_cook_food_hat_restaurant_icon__3_;
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2PictureBox1.Location = new System.Drawing.Point(32, 260);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(74, 90);
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnDeletePLam
            // 
            this.btnDeletePLam.Animated = true;
            this.btnDeletePLam.AutoRoundedCorners = true;
            this.btnDeletePLam.BorderColor = System.Drawing.Color.Empty;
            this.btnDeletePLam.BorderRadius = 17;
            this.btnDeletePLam.CheckedState.Parent = this.btnDeletePLam;
            this.btnDeletePLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePLam.CustomImages.Parent = this.btnDeletePLam;
            this.btnDeletePLam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(118)))), ((int)(((byte)(43)))));
            this.btnDeletePLam.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePLam.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeletePLam.HoverState.Parent = this.btnDeletePLam;
            this.btnDeletePLam.Location = new System.Drawing.Point(150, 370);
            this.btnDeletePLam.Name = "btnDeletePLam";
            this.btnDeletePLam.ShadowDecoration.Parent = this.btnDeletePLam;
            this.btnDeletePLam.Size = new System.Drawing.Size(145, 36);
            this.btnDeletePLam.TabIndex = 44;
            this.btnDeletePLam.Text = "Delete Plan";
            this.btnDeletePLam.Click += new System.EventHandler(this.btnDeletePLam_Click);
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
            this.btnBack.TabIndex = 45;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmViewPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 451);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeletePLam);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.pictureboxRecipe);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblRecipeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewPlan";
            this.Load += new System.EventHandler(this.frmViewPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxRecipe)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblRecipeName;
        private Guna.UI2.WinForms.Guna2PictureBox pictureboxRecipe;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Label lblDate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnDeletePLam;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}