using System;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>This partial class adds the url to be downloaded to the <c>BulkDownloadManager</c> class when this
    /// form is called.
    /// </summary>
    public partial class BulkDownloadAddUrl : Form
    {
        private readonly Browser _b;
        private readonly BulkDownloadManager _downloadManager;
        private readonly ToolStripMenuItem _menuItem;

        public BulkDownloadAddUrl(BulkDownloadManager downloadManager, Browser b, ToolStripMenuItem menuItem)
        {
            InitializeComponent();
            _downloadManager = downloadManager;
            _b = b;
            _menuItem = menuItem;
            // For faster typing add the initial url prefix. 
            enterUrlTextBox.Text = "https://";
        }

        /// <summary>
        /// Method <c>OkButton_Click</c> On Click listener to close the form when the Ok button is pressed. 
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!DisplayManager.UrlChecker(enterUrlTextBox.Text)) return;
            _downloadManager.Files.Add(enterUrlTextBox.Text);
            // Update the menu item when a new url is added
            _b.UpdateBulkDownload(_downloadManager, _menuItem, enterUrlTextBox.Text);
        }

        /// <summary>
        /// Method <c>EnterUrlTextBox_KeyDown</c> On key down listener to close the form when enter is pressed. 
        /// </summary>
        private void EnterUrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            // If pressing enter ensure that something has been typed in for the url. 
            var text = enterUrlTextBox.Text;
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)) return;
            if (!DisplayManager.UrlChecker(enterUrlTextBox.Text)) return;
            _downloadManager.Files.Add(enterUrlTextBox.Text);
            _b.UpdateBulkDownload(_downloadManager, _menuItem, enterUrlTextBox.Text);
            // This allows the form to be closed when pressing enter. 
            DialogResult = DialogResult.OK;
        }
    }
}