namespace Browser
{
    partial class AddFavouriteForm
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
            this.favouriteNameLabel = new System.Windows.Forms.Label();
            this.favouriteUrlLabel = new System.Windows.Forms.Label();
            this.favouriteNameTextBox = new System.Windows.Forms.TextBox();
            this.favouriteUrlTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // favouriteNameLabel
            // 
            this.favouriteNameLabel.AutoSize = true;
            this.favouriteNameLabel.Location = new System.Drawing.Point(84, 41);
            this.favouriteNameLabel.Name = "favouriteNameLabel";
            this.favouriteNameLabel.Size = new System.Drawing.Size(38, 13);
            this.favouriteNameLabel.TabIndex = 0;
            this.favouriteNameLabel.Text = "Name:";
            // 
            // favouriteUrlLabel
            // 
            this.favouriteUrlLabel.AutoSize = true;
            this.favouriteUrlLabel.Location = new System.Drawing.Point(84, 73);
            this.favouriteUrlLabel.Name = "favouriteUrlLabel";
            this.favouriteUrlLabel.Size = new System.Drawing.Size(23, 13);
            this.favouriteUrlLabel.TabIndex = 1;
            this.favouriteUrlLabel.Text = "Url:";
            // 
            // favouriteNameTextBox
            // 
            this.favouriteNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.favouriteNameTextBox.Location = new System.Drawing.Point(128, 38);
            this.favouriteNameTextBox.Name = "favouriteNameTextBox";
            this.favouriteNameTextBox.Size = new System.Drawing.Size(290, 20);
            this.favouriteNameTextBox.TabIndex = 2;
            this.favouriteNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FavouriteNameTextBox_KeyDown);
            // 
            // favouriteUrlTextBox
            // 
            this.favouriteUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.favouriteUrlTextBox.Location = new System.Drawing.Point(128, 70);
            this.favouriteUrlTextBox.Name = "favouriteUrlTextBox";
            this.favouriteUrlTextBox.Size = new System.Drawing.Size(290, 20);
            this.favouriteUrlTextBox.TabIndex = 3;
            this.favouriteUrlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FavouriteUrlTextBox_KeyDown);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(300, 113);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(170, 113);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddFavouriteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 158);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.favouriteUrlTextBox);
            this.Controls.Add(this.favouriteNameTextBox);
            this.Controls.Add(this.favouriteUrlLabel);
            this.Controls.Add(this.favouriteNameLabel);
            this.Name = "AddFavouriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Favourite Url";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label favouriteNameLabel;
        private System.Windows.Forms.Label favouriteUrlLabel;
        private System.Windows.Forms.TextBox favouriteNameTextBox;
        private System.Windows.Forms.TextBox favouriteUrlTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}