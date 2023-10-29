using System;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>This partial class deals with adding and editing new favourite urls added when this form is called. 
    /// </summary>
    public partial class AddFavouriteForm : Form
    {
        private readonly Browser _browser;
        private readonly ToolStripMenuItem _clickedItem;
        private readonly FavouriteUrl _favUrl;
        private readonly ToolStripMenuItem _item;
        private readonly FavouriteUrl _selected;

        /// <summary>
        /// Method <c>AddFavouriteForm</c> Used to add a new favourite url to the menu. 
        /// </summary>
        public AddFavouriteForm(FavouriteUrl favUrl, ToolStripMenuItem item, Browser browser, string currentUrl)
        {
            InitializeComponent();
            _favUrl = favUrl;
            _item = item;
            _browser = browser;
            favouriteUrlTextBox.Text = currentUrl;
        }

        /// <summary>
        /// Method <c>AddFavouriteForm</c> Used to edit a favourite url already in the menu.  
        /// </summary>
        public AddFavouriteForm(FavouriteUrl favUrl, ToolStripMenuItem item, Browser browser, FavouriteUrl selected,
            ToolStripMenuItem clickedItem)
        {
            InitializeComponent();
            _favUrl = favUrl;
            _item = item;
            _browser = browser;
            _selected = selected;
            _clickedItem = clickedItem;
            favouriteNameTextBox.Text = selected.Name;
            favouriteUrlTextBox.Text = selected.Url;
        }

        /// <summary>
        /// Method <c>OkButton_Click</c> On Click listener to close the form when the Ok button is pressed.
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!DisplayManager.UrlChecker(favouriteUrlTextBox.Text)) return;
            UpdateFavouriteUrl();
        }

        /// <summary>
        /// Method <c>UpdateFavouriteUrl</c> Updates the favourite menu with the new url or the edited url. 
        /// </summary>
        private void UpdateFavouriteUrl()
        {
            // This checks if you are updating a url instead of adding a new one to the favourites menu. 
            if (_clickedItem != null)
            {
                // Remove the old url and then add the updated url as a new item. 
                _favUrl.Favourite.Remove(_selected);
                var url = new FavouriteUrl(favouriteUrlTextBox.Text, favouriteNameTextBox.Text);
                _favUrl.Favourite.Add(url);
                // Update the menu items by removing the old one and adding the updated one as a new item. 
                _browser.UpdateFavouriteUrl(url, _item);
                _browser.DeleteFavMenuItem(_selected);
            }
            else
            {
                // If not editing a menu item then add a new favourite url instead
                var url = new FavouriteUrl(favouriteUrlTextBox.Text, favouriteNameTextBox.Text);
                _favUrl.Favourite.Add(url);
                _browser.UpdateFavouriteUrl(url, _item);
            }
        }

        /// <summary>
        /// Method <c>FavouriteNameTextBox_KeyDown</c> On key down listener to close the form when enter is pressed. 
        /// </summary>
        private void FavouriteNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyPressed(e);
        }

        /// <summary>
        /// Method <c>FavouriteUrlTextBox_KeyDown</c> On key down listener to close the form when enter is pressed. 
        /// </summary>
        private void FavouriteUrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            EnterKeyPressed(e);
        }
        
        /// <summary>
        /// Method <c>EnterKeyPressed</c> Makes sure when enter is pressed nothing is empty and a valid url is given. 
        /// </summary>
        private void EnterKeyPressed(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var name = favouriteNameTextBox.Text;
            var url = favouriteUrlTextBox.Text;
            if (!DisplayManager.UrlChecker(favouriteUrlTextBox.Text)) return;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(url) ||
                string.IsNullOrWhiteSpace(url)) return;
            // If all the checks pass then perform the add or edit of the favourite url. 
            UpdateFavouriteUrl();
            // This allows the form to be closed when pressing enter. 
            DialogResult = DialogResult.OK;
        }
    }
}