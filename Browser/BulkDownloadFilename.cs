using System;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>This partial class allows the name of the downloaded filename to be changed when this form is called.
    /// </summary>
    public partial class BulkDownloadFilename : Form
    {
        private readonly BulkDownloadManager _downloadManager;

        public BulkDownloadFilename(BulkDownloadManager downloadManager)
        {
            InitializeComponent();
            _downloadManager = downloadManager;
            // Populate the filename field with the current file name.  
            enterFilenameTextBox.Text = downloadManager.DownloadTextFileName;
        }

        /// <summary>
        /// Method <c>OkButton_Click</c> On Click listener for when the Ok button is pressed. 
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            _downloadManager.DownloadTextFileName = enterFilenameTextBox.Text;
        }

        /// <summary>
        /// Method <c>EnterFilenameTextBox_KeyDown</c> On key down listener to close the form when enter is pressed. 
        /// </summary>
        private void EnterFilenameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            // Ensure the new filename isn't empty. 
            var text = enterFilenameTextBox.Text;
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text)) return;
            _downloadManager.DownloadTextFileName = enterFilenameTextBox.Text;
            // This allows the form to be closed when pressing enter. 
            DialogResult = DialogResult.OK;
        }
    }
}