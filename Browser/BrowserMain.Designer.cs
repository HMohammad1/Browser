namespace Browser
{
    partial class Browser
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
            this.menuLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.refreshPictureBox = new System.Windows.Forms.PictureBox();
            this.homePagePictureBox = new System.Windows.Forms.PictureBox();
            this.goNextPictureBox = new System.Windows.Forms.PictureBox();
            this.goBackPictureBox = new System.Windows.Forms.PictureBox();
            this.enterUrlPictureBox = new System.Windows.Forms.PictureBox();
            this.displayHTMLRichTextBox = new System.Windows.Forms.RichTextBox();
            this.statusCodeTextBox = new System.Windows.Forms.TextBox();
            this.responseMessageTextBox = new System.Windows.Forms.TextBox();
            this.statusCodeLabel = new System.Windows.Forms.Label();
            this.responseMessageLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editHomepageUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFavouriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specifyFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.titleLabel = new System.Windows.Forms.Label();
            this.urlTitleTextBox = new System.Windows.Forms.TextBox();
            this.menuLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homePagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goNextPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goBackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterUrlPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuLayoutPanel
            // 
            this.menuLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuLayoutPanel.ColumnCount = 6;
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.menuLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.menuLayoutPanel.Controls.Add(this.urlTextBox, 4, 0);
            this.menuLayoutPanel.Controls.Add(this.refreshPictureBox, 3, 0);
            this.menuLayoutPanel.Controls.Add(this.homePagePictureBox, 2, 0);
            this.menuLayoutPanel.Controls.Add(this.goNextPictureBox, 1, 0);
            this.menuLayoutPanel.Controls.Add(this.goBackPictureBox, 0, 0);
            this.menuLayoutPanel.Controls.Add(this.enterUrlPictureBox, 5, 0);
            this.menuLayoutPanel.Location = new System.Drawing.Point(12, 24);
            this.menuLayoutPanel.Name = "menuLayoutPanel";
            this.menuLayoutPanel.RowCount = 1;
            this.menuLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuLayoutPanel.Size = new System.Drawing.Size(763, 25);
            this.menuLayoutPanel.TabIndex = 0;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlTextBox.Location = new System.Drawing.Point(123, 3);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(604, 20);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.DoubleClick += new System.EventHandler(this.UrlTextBox_DoubleClick);
            this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlTextBox_KeyDown);
            // 
            // refreshPictureBox
            // 
            this.refreshPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshPictureBox.InitialImage = null;
            this.refreshPictureBox.Location = new System.Drawing.Point(93, 3);
            this.refreshPictureBox.Name = "refreshPictureBox";
            this.refreshPictureBox.Size = new System.Drawing.Size(24, 19);
            this.refreshPictureBox.TabIndex = 1;
            this.refreshPictureBox.TabStop = false;
            this.refreshPictureBox.Click += new System.EventHandler(this.RefreshPictureBox_Click);
            // 
            // homePagePictureBox
            // 
            this.homePagePictureBox.Location = new System.Drawing.Point(63, 3);
            this.homePagePictureBox.Name = "homePagePictureBox";
            this.homePagePictureBox.Size = new System.Drawing.Size(24, 19);
            this.homePagePictureBox.TabIndex = 2;
            this.homePagePictureBox.TabStop = false;
            this.homePagePictureBox.Click += new System.EventHandler(this.HomePagePictureBox_Click);
            // 
            // goNextPictureBox
            // 
            this.goNextPictureBox.Location = new System.Drawing.Point(33, 3);
            this.goNextPictureBox.Name = "goNextPictureBox";
            this.goNextPictureBox.Size = new System.Drawing.Size(24, 19);
            this.goNextPictureBox.TabIndex = 3;
            this.goNextPictureBox.TabStop = false;
            this.goNextPictureBox.Click += new System.EventHandler(this.GoNextPictureBox_Click);
            // 
            // goBackPictureBox
            // 
            this.goBackPictureBox.Location = new System.Drawing.Point(3, 3);
            this.goBackPictureBox.Name = "goBackPictureBox";
            this.goBackPictureBox.Size = new System.Drawing.Size(24, 19);
            this.goBackPictureBox.TabIndex = 4;
            this.goBackPictureBox.TabStop = false;
            this.goBackPictureBox.Click += new System.EventHandler(this.GoBackPictureBox_Click);
            // 
            // enterUrlPictureBox
            // 
            this.enterUrlPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterUrlPictureBox.Location = new System.Drawing.Point(733, 3);
            this.enterUrlPictureBox.Name = "enterUrlPictureBox";
            this.enterUrlPictureBox.Size = new System.Drawing.Size(27, 19);
            this.enterUrlPictureBox.TabIndex = 5;
            this.enterUrlPictureBox.TabStop = false;
            this.enterUrlPictureBox.Click += new System.EventHandler(this.enterUrlPictureBox_Click);
            // 
            // displayHTMLRichTextBox
            // 
            this.displayHTMLRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayHTMLRichTextBox.Location = new System.Drawing.Point(12, 88);
            this.displayHTMLRichTextBox.Name = "displayHTMLRichTextBox";
            this.displayHTMLRichTextBox.ReadOnly = true;
            this.displayHTMLRichTextBox.Size = new System.Drawing.Size(763, 350);
            this.displayHTMLRichTextBox.TabIndex = 1;
            this.displayHTMLRichTextBox.TabStop = false;
            this.displayHTMLRichTextBox.Text = "";
            this.displayHTMLRichTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Browser_KeyUp);
            // 
            // statusCodeTextBox
            // 
            this.statusCodeTextBox.Enabled = false;
            this.statusCodeTextBox.Location = new System.Drawing.Point(78, 53);
            this.statusCodeTextBox.Name = "statusCodeTextBox";
            this.statusCodeTextBox.ReadOnly = true;
            this.statusCodeTextBox.Size = new System.Drawing.Size(92, 20);
            this.statusCodeTextBox.TabIndex = 2;
            this.statusCodeTextBox.TabStop = false;
            // 
            // responseMessageTextBox
            // 
            this.responseMessageTextBox.Enabled = false;
            this.responseMessageTextBox.Location = new System.Drawing.Point(282, 53);
            this.responseMessageTextBox.Name = "responseMessageTextBox";
            this.responseMessageTextBox.ReadOnly = true;
            this.responseMessageTextBox.Size = new System.Drawing.Size(177, 20);
            this.responseMessageTextBox.TabIndex = 3;
            this.responseMessageTextBox.TabStop = false;
            // 
            // statusCodeLabel
            // 
            this.statusCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusCodeLabel.AutoSize = true;
            this.statusCodeLabel.Location = new System.Drawing.Point(10, 57);
            this.statusCodeLabel.Name = "statusCodeLabel";
            this.statusCodeLabel.Size = new System.Drawing.Size(65, 13);
            this.statusCodeLabel.TabIndex = 4;
            this.statusCodeLabel.Text = "Status Code";
            // 
            // responseMessageLabel
            // 
            this.responseMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.responseMessageLabel.AutoSize = true;
            this.responseMessageLabel.Location = new System.Drawing.Point(174, 57);
            this.responseMessageLabel.Name = "responseMessageLabel";
            this.responseMessageLabel.Size = new System.Drawing.Size(101, 13);
            this.responseMessageLabel.TabIndex = 5;
            this.responseMessageLabel.Text = "Response Message";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.favouritesToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.bulkDownloadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editHomepageUrlToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // editHomepageUrlToolStripMenuItem
            // 
            this.editHomepageUrlToolStripMenuItem.Name = "editHomepageUrlToolStripMenuItem";
            this.editHomepageUrlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.editHomepageUrlToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editHomepageUrlToolStripMenuItem.Text = "Edit &Homepage Url";
            this.editHomepageUrlToolStripMenuItem.Click += new System.EventHandler(this.EditHomepageUrlToolStripMenuItem_Click);
            // 
            // favouritesToolStripMenuItem
            // 
            this.favouritesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFavouriteToolStripMenuItem});
            this.favouritesToolStripMenuItem.Name = "favouritesToolStripMenuItem";
            this.favouritesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.favouritesToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.favouritesToolStripMenuItem.Text = "F&avourites";
            // 
            // addFavouriteToolStripMenuItem
            // 
            this.addFavouriteToolStripMenuItem.Name = "addFavouriteToolStripMenuItem";
            this.addFavouriteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.addFavouriteToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addFavouriteToolStripMenuItem.Text = "&Add Favourite";
            this.addFavouriteToolStripMenuItem.Click += new System.EventHandler(this.AddFavouriteToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.historyToolStripMenuItem.Text = "&History";
            // 
            // bulkDownloadToolStripMenuItem
            // 
            this.bulkDownloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToDownloadToolStripMenuItem,
            this.specifyFilenameToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.toolStripSeparator1});
            this.bulkDownloadToolStripMenuItem.Name = "bulkDownloadToolStripMenuItem";
            this.bulkDownloadToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.bulkDownloadToolStripMenuItem.Text = "&Bulk Download";
            // 
            // addToDownloadToolStripMenuItem
            // 
            this.addToDownloadToolStripMenuItem.Name = "addToDownloadToolStripMenuItem";
            this.addToDownloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D)));
            this.addToDownloadToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.addToDownloadToolStripMenuItem.Text = "&Add to download";
            this.addToDownloadToolStripMenuItem.Click += new System.EventHandler(this.AddToDownloadToolStripMenuItem_Click);
            // 
            // specifyFilenameToolStripMenuItem
            // 
            this.specifyFilenameToolStripMenuItem.Name = "specifyFilenameToolStripMenuItem";
            this.specifyFilenameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.F)));
            this.specifyFilenameToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.specifyFilenameToolStripMenuItem.Text = "&Specify filename";
            this.specifyFilenameToolStripMenuItem.Click += new System.EventHandler(this.SpecifyFilenameToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.J)));
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.downloadToolStripMenuItem.Text = "&Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.DownloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(465, 57);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title";
            // 
            // urlTitleTextBox
            // 
            this.urlTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTitleTextBox.Enabled = false;
            this.urlTitleTextBox.Location = new System.Drawing.Point(498, 53);
            this.urlTitleTextBox.Name = "urlTitleTextBox";
            this.urlTitleTextBox.ReadOnly = true;
            this.urlTitleTextBox.Size = new System.Drawing.Size(274, 20);
            this.urlTitleTextBox.TabIndex = 8;
            this.urlTitleTextBox.TabStop = false;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 450);
            this.Controls.Add(this.urlTitleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.responseMessageLabel);
            this.Controls.Add(this.statusCodeLabel);
            this.Controls.Add(this.responseMessageTextBox);
            this.Controls.Add(this.statusCodeTextBox);
            this.Controls.Add(this.displayHTMLRichTextBox);
            this.Controls.Add(this.menuLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Browser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Browser_KeyUp);
            this.menuLayoutPanel.ResumeLayout(false);
            this.menuLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homePagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goNextPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goBackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enterUrlPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel menuLayoutPanel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.RichTextBox displayHTMLRichTextBox;
        private System.Windows.Forms.TextBox statusCodeTextBox;
        private System.Windows.Forms.TextBox responseMessageTextBox;
        private System.Windows.Forms.Label statusCodeLabel;
        private System.Windows.Forms.Label responseMessageLabel;
        private System.Windows.Forms.PictureBox refreshPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editHomepageUrlToolStripMenuItem;
        private System.Windows.Forms.PictureBox homePagePictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox urlTitleTextBox;
        private System.Windows.Forms.ToolStripMenuItem favouritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFavouriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.PictureBox goNextPictureBox;
        private System.Windows.Forms.PictureBox goBackPictureBox;
        private System.Windows.Forms.ToolStripMenuItem bulkDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specifyFilenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.PictureBox enterUrlPictureBox;
    }
}

