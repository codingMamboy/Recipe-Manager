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
            this.txtIngredients = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtInstructions = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = true;
            this.lblRecipeName.Location = new System.Drawing.Point(190, 170);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(35, 13);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "label1";
            // 
            // txtIngredients
            // 
            this.txtIngredients.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIngredients.DefaultText = "";
            this.txtIngredients.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIngredients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIngredients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIngredients.DisabledState.Parent = this.txtIngredients;
            this.txtIngredients.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIngredients.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIngredients.FocusedState.Parent = this.txtIngredients;
            this.txtIngredients.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIngredients.HoverState.Parent = this.txtIngredients;
            this.txtIngredients.Location = new System.Drawing.Point(367, 12);
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.PasswordChar = '\0';
            this.txtIngredients.PlaceholderText = "";
            this.txtIngredients.SelectedText = "";
            this.txtIngredients.ShadowDecoration.Parent = this.txtIngredients;
            this.txtIngredients.Size = new System.Drawing.Size(320, 217);
            this.txtIngredients.TabIndex = 2;
            // 
            // txtInstructions
            // 
            this.txtInstructions.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInstructions.DefaultText = "";
            this.txtInstructions.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInstructions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInstructions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInstructions.DisabledState.Parent = this.txtInstructions;
            this.txtInstructions.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInstructions.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInstructions.FocusedState.Parent = this.txtInstructions;
            this.txtInstructions.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInstructions.HoverState.Parent = this.txtInstructions;
            this.txtInstructions.Location = new System.Drawing.Point(429, 270);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.PasswordChar = '\0';
            this.txtInstructions.PlaceholderText = "";
            this.txtInstructions.SelectedText = "";
            this.txtInstructions.ShadowDecoration.Parent = this.txtInstructions;
            this.txtInstructions.Size = new System.Drawing.Size(277, 231);
            this.txtInstructions.TabIndex = 3;
            // 
            // frmViewRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 590);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.txtIngredients);
            this.Controls.Add(this.lblRecipeName);
            this.Name = "frmViewRecipe";
            this.Text = "frmViewRecipe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecipeName;
        private Guna.UI2.WinForms.Guna2TextBox txtIngredients;
        private Guna.UI2.WinForms.Guna2TextBox txtInstructions;
    }
}