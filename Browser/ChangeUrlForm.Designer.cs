namespace Browser
{
    partial class ChangeUrlForm
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
            this.enterUrlLabel = new System.Windows.Forms.Label();
            this.enterUrlTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterUrlLabel
            // 
            this.enterUrlLabel.AutoSize = true;
            this.enterUrlLabel.Location = new System.Drawing.Point(21, 67);
            this.enterUrlLabel.Name = "enterUrlLabel";
            this.enterUrlLabel.Size = new System.Drawing.Size(54, 13);
            this.enterUrlLabel.TabIndex = 0;
            this.enterUrlLabel.Text = "Enter Url: ";
            // 
            // enterUrlTextBox
            // 
            this.enterUrlTextBox.Location = new System.Drawing.Point(81, 60);
            this.enterUrlTextBox.Name = "enterUrlTextBox";
            this.enterUrlTextBox.Size = new System.Drawing.Size(439, 20);
            this.enterUrlTextBox.TabIndex = 1;
            this.enterUrlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterUrlTextBox_KeyDown);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(171, 120);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(301, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ChangeUrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 158);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.enterUrlTextBox);
            this.Controls.Add(this.enterUrlLabel);
            this.Name = "ChangeUrlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Url";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label enterUrlLabel;
        private System.Windows.Forms.TextBox enterUrlTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}