namespace Browser
{
    partial class BulkDownloadFilename
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.enterFilenameTextBox = new System.Windows.Forms.TextBox();
            this.enterFilenameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(328, 113);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(198, 113);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // enterFilenameTextBox
            // 
            this.enterFilenameTextBox.Location = new System.Drawing.Point(108, 57);
            this.enterFilenameTextBox.Name = "enterFilenameTextBox";
            this.enterFilenameTextBox.Size = new System.Drawing.Size(439, 20);
            this.enterFilenameTextBox.TabIndex = 5;
            this.enterFilenameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterFilenameTextBox_KeyDown);
            // 
            // enterFilenameLabel
            // 
            this.enterFilenameLabel.AutoSize = true;
            this.enterFilenameLabel.Location = new System.Drawing.Point(19, 60);
            this.enterFilenameLabel.Name = "enterFilenameLabel";
            this.enterFilenameLabel.Size = new System.Drawing.Size(83, 13);
            this.enterFilenameLabel.TabIndex = 4;
            this.enterFilenameLabel.Text = "Enter Filename: ";
            // 
            // BulkDownloadFilename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 188);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.enterFilenameTextBox);
            this.Controls.Add(this.enterFilenameLabel);
            this.Name = "BulkDownloadFilename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Filename";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox enterFilenameTextBox;
        private System.Windows.Forms.Label enterFilenameLabel;
    }
}