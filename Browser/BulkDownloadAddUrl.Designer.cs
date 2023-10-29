namespace Browser
{
    partial class BulkDownloadAddUrl
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
            this.enterUrlTextBox = new System.Windows.Forms.TextBox();
            this.enterUrlLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(343, 109);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(213, 109);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // enterUrlTextBox
            // 
            this.enterUrlTextBox.Location = new System.Drawing.Point(123, 53);
            this.enterUrlTextBox.Name = "enterUrlTextBox";
            this.enterUrlTextBox.Size = new System.Drawing.Size(439, 20);
            this.enterUrlTextBox.TabIndex = 9;
            this.enterUrlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterUrlTextBox_KeyDown);
            // 
            // enterUrlLabel
            // 
            this.enterUrlLabel.AutoSize = true;
            this.enterUrlLabel.Location = new System.Drawing.Point(34, 56);
            this.enterUrlLabel.Name = "enterUrlLabel";
            this.enterUrlLabel.Size = new System.Drawing.Size(51, 13);
            this.enterUrlLabel.TabIndex = 8;
            this.enterUrlLabel.Text = "Enter Url ";
            // 
            // BulkDownloadAddUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 185);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.enterUrlTextBox);
            this.Controls.Add(this.enterUrlLabel);
            this.Name = "BulkDownloadAddUrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Url To Download";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox enterUrlTextBox;
        private System.Windows.Forms.Label enterUrlLabel;
    }
}