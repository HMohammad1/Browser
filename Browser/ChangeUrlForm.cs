using System;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>This partial class deals with changing the homepage url when this form is called. 
    /// <para>
    /// This form allows both enter an the Ok button to be used to continue ensuring that a valid url is given.  
    /// </para>
    /// </summary>
    public partial class ChangeUrlForm : Form
    {
        public ChangeUrlForm()
        {
            InitializeComponent();
            enterUrlTextBox.Text = "https://";
        }

        /// <summary>
        /// Method <c>OkButton_Click</c> On Click listener to close the form when the Ok button is pressed. 
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!DisplayManager.UrlChecker(enterUrlTextBox.Text)) return;
            // Update the text file containing the home page url every time it is changed. 
            FileManager.WriteStartupWebpage(enterUrlTextBox.Text);
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
            FileManager.WriteStartupWebpage(enterUrlTextBox.Text);
            // This allows the form to be closed when pressing enter. 
            DialogResult = DialogResult.OK;
        }
    }
}