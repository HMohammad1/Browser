using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>This is the main form and deals with different interactions with the user.
    /// <para>
    /// This class handles all the button clicks, keyboard shortcuts and menu item clicks and what will happen when each
    /// of those are pressed. It also handles all the on click listeners and methods to be called then these are clicked.
    /// A background worker is used to run url queries to not block the UI thread.  
    /// </para>
    /// </summary>
    public partial class Browser : Form
    {
        private readonly BulkDownloadManager _bulkDownloadManager;
        private readonly FavouriteUrl _favUrl;
        private readonly HistoryManager _historyManager;
        private readonly InitialiseHtml _html;
        private string _currentUrl;
        private readonly BackgroundWorker _backgroundWorker;

        public Browser()
        {
            InitializeComponent();
            SetImages();
            SetDropDownSizes();
            urlTextBox.Text = FileManager.ReadStartupWebpage();
            _html = DisplayManager.DisplayHtml;
            _favUrl = new FavouriteUrl();
            _historyManager = new HistoryManager();
            _currentUrl = FileManager.ReadStartupWebpage();
            _bulkDownloadManager = new BulkDownloadManager();
            // Make a new background worker for large tasks
            _backgroundWorker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            SetBackgroundWorker();
        }
        
        /// <summary>
        /// Method <c>SetBackgroundWorker</c> Adds the listeners for <c>DoWork</c> and <c>RunWorkerCompleted</c>. 
        /// </summary>
        private void SetBackgroundWorker()
        {
            _backgroundWorker.DoWork += DoWork;
            _backgroundWorker.RunWorkerCompleted += BwUpdateHistoryRunWorkerCompleted;
        }

        /// <summary>
        /// Method <c>DoWork</c> Display the html data and change the icon while the html is retrieved.
        /// </summary>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            ChangeSearchImage();
            InvokeDelegate(_html);
        }
        
        
        /// <summary>
        /// Method <c>ChangeSearchImage</c> Changes the search icon to a cross when html is being retrieved. 
        /// </summary>
        private void ChangeSearchImage()
        {
            enterUrlPictureBox.ImageLocation = "Images\\cancel.png";
            enterUrlPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        /// <summary>
        /// Method <c>BwUpdateHistoryRunWorkerCompleted</c> Logic for what happens when a background worker is completed.
        /// Ensure that the cross icon is updated back to the search icon regardless. 
        /// </summary>
        private void BwUpdateHistoryRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs  e)
        {
            if (e.Cancelled)
            {
                enterUrlPictureBox.ImageLocation = "Images\\search.jpg";
                enterUrlPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (e.Error != null)
            {
                enterUrlPictureBox.ImageLocation = "Images\\search.jpg";
                enterUrlPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                enterUrlPictureBox.ImageLocation = "Images\\search.jpg";
                enterUrlPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// Method <c>SetImages</c> Setup all the image icons to be used in this browser.  
        /// </summary>
        private void SetImages()
        {
            refreshPictureBox.ImageLocation = "Images\\refresh.png";
            refreshPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            homePagePictureBox.ImageLocation = "Images\\homepage.png";
            homePagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            goBackPictureBox.ImageLocation = "Images\\back.jpg";
            goBackPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            goNextPictureBox.ImageLocation = "Images\\forward.jpg";
            goNextPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            enterUrlPictureBox.ImageLocation = "Images\\search.jpg";
            enterUrlPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Method <c>SetDropDownSizes</c> Setup the max dropdown size for all the menus so they don't keep expanding. 
        /// </summary>
        private void SetDropDownSizes()
        {
            historyToolStripMenuItem.DropDown.MaximumSize = new Size(250, 400);
            favouritesToolStripMenuItem.DropDown.MaximumSize = new Size(250, 400);
            bulkDownloadToolStripMenuItem.DropDown.MaximumSize = new Size(250, 400);
        }
        
        /// <summary>
        /// Method <c>Browser_Load</c> When the browser is first started the history and favourite urls need to be loaded
        /// in and populated. Also load up the homepage without a history update.  
        /// </summary>
        private void Browser_Load(object sender, EventArgs e)
        {
            FileManager.ReadHistory(_historyManager);
            FileManager.ReadFavouriteUrl(_favUrl);
            UpdateHistory();
            _backgroundWorker.RunWorkerAsync();
            UpdateFavouriteUrl();
        }
        

        /// <summary>
        /// Method <c>UpdateFavouriteUrl</c> Populates the favourite urls inside its menu and adds its on click listeners. 
        /// </summary>
        private void UpdateFavouriteUrl()
        {
            foreach (var menuItem in _favUrl.Favourite.Select(item => new ToolStripMenuItem(item.Name)
                     {
                         Tag = item
                     }))
            {
                menuItem.Click += FavouriteMenuItem_Clicked;
                menuItem.MouseDown += ToolStripButton_MouseClick;
                favouritesToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Method <c>InvokeDelegate</c> Invokes the delegate that retrieves the results from entering a url into the
        /// search bar.  
        /// </summary>
        private void InvokeDelegate(InitialiseHtml html)
        {
            html(urlTextBox, displayHTMLRichTextBox, statusCodeTextBox, responseMessageTextBox, urlTitleTextBox);
        }

        /// <summary>
        /// Method <c>UpdateHistoryProperties</c> Run the update history method. Also updates the current url
        /// and resets the forward list since this is called when you search from the searchbar.  
        /// </summary>
        private void UpdateHistoryProperties()
        {
            _historyManager.AddHistory(urlTextBox.Text);
            UpdateHistory(urlTextBox.Text, historyToolStripMenuItem);
            _historyManager.SetGoBackwardList(_currentUrl);
            _currentUrl = urlTextBox.Text;
            _historyManager.ResetForwardListIndex();
        }

        /// <summary>
        /// Method <c>enterUrlPictureBox_Click</c> On click listener to display the results of the url query.  
        /// </summary>
        private void enterUrlPictureBox_Click(object sender, EventArgs e)
        {
            UpdateHistoryProperties();
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }
        
        /// <summary>
        /// Method <c>UrlTextBox_KeyDown</c> Key down listener when enter is pressed to display the results of the url
        /// typed in.  
        /// </summary>
        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Change the cursor icon to show the action went through. 
                Cursor = Cursors.WaitCursor;
                UpdateHistoryProperties();
                if (!_backgroundWorker.IsBusy)
                {
                    _backgroundWorker.RunWorkerAsync();
                }
                Cursor = Cursors.Default;
            }

            // Add the shortcuts for other menu items even when the search bar is the selected item. 
            GoForwardShortcut(e);
            GoBackShortcut(e);
            ReloadShortcut(e);
            HomepageShortcut(e);
            HistoryShortcut(e);

        }

        /// <summary>
        /// Method <c>UrlTextBox_DoubleClick</c> On click listener to select all the text when double clicking inside
        /// the search bar.  
        /// </summary>
        private void UrlTextBox_DoubleClick(object sender, EventArgs e)
        {
            urlTextBox.SelectAll();
        }

        /// <summary>
        /// Method <c>RefreshPictureBox_Click</c> On click listener to re run the html query and display the reloaded data.
        /// Should not update the history.  
        /// </summary>
        private void RefreshPictureBox_Click(object sender, EventArgs e)
        {
            refreshPictureBox.BorderStyle = BorderStyle.Fixed3D;
            Cursor = Cursors.WaitCursor;
            // Ensure background worker is not being used before running this. 
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
            Cursor = Cursors.Default;
            refreshPictureBox.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Method <c>UpdateHistory</c> Populates the history menu when first opening the browser.   
        /// </summary>
        private void UpdateHistory()
        {
            foreach (var menuItem in _historyManager.History.Select(text => new ToolStripMenuItem(text)
                     {
                         Tag = text
                     }))
            {
                menuItem.Click += HistoryMenuItem_Clicked;
                historyToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Method <c>UpdateHistory</c> Adds a new menu item to the history menu.    
        /// </summary>
        private void UpdateHistory(string url, ToolStripMenuItem item)
        {
            var menuItem = new ToolStripMenuItem(url)
            {
                Tag = url
            };
            menuItem.Click += HistoryMenuItem_Clicked;
            item.DropDownItems.Add(menuItem);
        }

        /// <summary>
        /// Method <c>HistoryMenuItem_Clicked</c> On click listener to search the url when it is clicked. Should update
        /// the history since a new search is done. 
        /// </summary>
        private void HistoryMenuItem_Clicked(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedItem)) return;
            urlTextBox.Text = clickedItem.Text;
            UpdateHistoryProperties();
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Method <c>ToolStripButton_MouseClick</c> On click listener for when the right click is pressed for a menu item
        /// in the favourites menu. Displays the Delete and Edit options.  
        /// </summary>
        private void ToolStripButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (sender is ToolStripMenuItem item && item.Tag is FavouriteUrl selectedObject)
            {
                var contextMenu = new ContextMenuStrip();
                var menuItem = new ToolStripMenuItem("Delete");
                var menuItem2 = new ToolStripMenuItem("Edit");
                menuItem2.Tag = selectedObject;
                menuItem.Tag = selectedObject;
                menuItem.Click += DeleteFavItem_CLicked;
                menuItem2.Click += EditFavItem_CLicked;

                contextMenu.Items.Add(menuItem);
                contextMenu.Items.Add(menuItem2);
                // Display these items where the favourite menu is located. 
                contextMenu.Show(this, e.Location);
            }
            // Ensure the click event happens straight away. 
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Method <c>EditFavItem_CLicked</c> On click listener for when edit is clicked inside the favourites menu,
        /// runs the method to show the edit form. 
        /// </summary>
        private void EditFavItem_CLicked(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedItem) || !(clickedItem.Tag is FavouriteUrl selectedObject)) return;
            DisplayManager.EditFavouriteUrl(_favUrl, favouritesToolStripMenuItem, this, selectedObject, clickedItem);
        }

        /// <summary>
        /// Method <c>DeleteFavItem_CLicked</c> On click listener for when delete is clicked inside the favourites menu
        /// and delete the item. 
        /// </summary>
        private void DeleteFavItem_CLicked(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedItem) || !(clickedItem.Tag is FavouriteUrl selectedObject)) return;
            _favUrl.Favourite.Remove(selectedObject);
            DeleteFavMenuItem(selectedObject);
        }

        /// <summary>
        /// Method <c>DeleteFavMenuItem</c> Retrieves the physical menu item from the menu by getting the selected item
        /// </summary>
        public void DeleteFavMenuItem(FavouriteUrl selectedObject)
        {
            foreach (ToolStripMenuItem menuItem in favouritesToolStripMenuItem.DropDownItems)
            {
                if (menuItem.Tag != selectedObject) continue;
                // Performs the actual removing from the menu 
                RemoveDropDownItem(menuItem);
                return;
            }
        }

        /// <summary>
        /// Method <c>EditHomepageUrlToolStripMenuItem_Click</c> On click listener to display the form to change the
        /// homepage url. 
        /// </summary>
        private void EditHomepageUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayManager.ChangeUrl();
        }

        /// <summary>
        /// Method <c>HomePagePictureBox_Click</c> On click listener to go to the home page, should update history. 
        /// </summary>
        private void HomePagePictureBox_Click(object sender, EventArgs e)
        {
            homePagePictureBox.BorderStyle = BorderStyle.Fixed3D;
            var url = FileManager.ReadStartupWebpage();
            urlTextBox.Text = url;
            UpdateHistoryProperties();
            // Ensure the background worker is not busy. 
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
            homePagePictureBox.BorderStyle = BorderStyle.None;
        }

        /// <summary>
        /// Method <c>AddFavouriteToolStripMenuItem_Click</c> On click listener to display the form to add a new
        /// favourite menu item. 
        /// </summary>
        private void AddFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayManager.AddFavouriteUrl(_favUrl, favouritesToolStripMenuItem, this, _currentUrl);
        }

        /// <summary>
        /// Method <c>UpdateFavouriteUrl</c> Update the favourites menu with the new item and add it's event listeners. 
        /// favourite menu item. 
        /// </summary>
        public void UpdateFavouriteUrl(FavouriteUrl url, ToolStripMenuItem item)
        {
            var menuItem = new ToolStripMenuItem(url.Name);
            menuItem.Click += FavouriteMenuItem_Clicked;
            menuItem.MouseDown += ToolStripButton_MouseClick;
            menuItem.Tag = url;
            item.DropDownItems.Add(menuItem);
        }

        /// <summary>
        /// Method <c>FavouriteMenuItem_Clicked</c> On click listener to go to the url when a favourite menu item is clicked.  
        /// </summary>
        private void FavouriteMenuItem_Clicked(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedItem) || !(clickedItem.Tag is FavouriteUrl selected)) return;
            urlTextBox.Text = selected.Url;
            UpdateHistoryProperties();
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Method <c>GoBackPictureBox_Click</c> On click listener to go back to the previous web page. Updates the
        /// current url.  
        /// </summary>
        private void GoBackPictureBox_Click(object sender, EventArgs e)
        {
            var url = _historyManager.GoBack(_currentUrl);
            if (url == null) return;
            _currentUrl = url;
            urlTextBox.Text = _currentUrl;
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Method <c>GoNextPictureBox_Click</c> On click listener to go forward to the next web page. Updates the
        /// current url.  
        /// </summary>
        private void GoNextPictureBox_Click(object sender, EventArgs e)
        {
            var url = _historyManager.GoForward(_currentUrl);
            if (url == null) return;
            _currentUrl = url;
            urlTextBox.Text = _currentUrl;
            if (!_backgroundWorker.IsBusy)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Method <c>SpecifyFilenameToolStripMenuItem_Click</c> On click listener to display the form to change the name
        /// of the filename when downloading it.  
        /// </summary>
        private void SpecifyFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayManager.SpecifyDownloadFileName(_bulkDownloadManager);
        }

        /// <summary>
        /// Method <c>AddToDownloadToolStripMenuItem_Click</c> On click listener to show the form to add a new item to
        /// be downloaded by the bulk download. 
        /// </summary>
        private void AddToDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayManager.AddNewDownloadUrl(_bulkDownloadManager, this, bulkDownloadToolStripMenuItem);
        }

        /// <summary>
        /// Method <c>UpdateBulkDownload</c> Updates the bulk download menu with the new item. Adds a tool tip to the
        /// item to let them know how to delete the item from the list.  
        /// </summary>
        public void UpdateBulkDownload(BulkDownloadManager manager, ToolStripMenuItem item, string url)
        {
            var menuItem = new ToolStripMenuItem(url);
            menuItem.Click += DeleteBulkDownloadItem_Click;
            menuItem.ToolTipText = "Click to delete";
            menuItem.Tag = manager;
            item.DropDownItems.Add(menuItem);
        }

        /// <summary>
        /// Method <c>DeleteBulkDownloadItem_Click</c> Deletes the bulk download menu item and removes the url from the
        /// download list.  
        /// </summary>
        private void DeleteBulkDownloadItem_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem item) || !(item.Tag is BulkDownloadManager)) return;
            _bulkDownloadManager.Files.Remove(item.Text);
            RemoveDropDownItem(item);
        }

        /// <summary>
        /// Method <c>RemoveDropDownItem</c> Performs the actual removing of the menu item from the menu.   
        /// </summary>
        private static void RemoveDropDownItem(ToolStripMenuItem item)
        {
            if (!(item.Owner is ToolStrip owner)) return;
            item.Owner.Items.Remove(item);
            owner.PerformLayout();
        }

        /// <summary>
        /// Method <c>DownloadToolStripMenuItem_Click</c> Calls <c>DisplayManager.DownloadItems</c> to download the urls
        /// that have been entered.  
        /// </summary>
        private void DownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayManager.DownloadItems(_bulkDownloadManager, urlTextBox, displayHTMLRichTextBox);
        }

        /// <summary>
        /// Method <c>GoBackShortcut</c> On key listener shortcut for going to the previous page
        /// </summary>
        private void GoBackShortcut(KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left) GoBackPictureBox_Click(this, e);
        }
        
        /// <summary>
        /// Method <c>GoForwardShortcut</c> On key listener shortcut for going to the next page
        /// </summary>
        private void GoForwardShortcut(KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right) GoNextPictureBox_Click(this, e);
        }

        /// <summary>
        /// Method <c>ReloadShortcut</c> On key listener shortcut for reloading the current page
        /// </summary>
        private void ReloadShortcut(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R) RefreshPictureBox_Click(this, e);
        }

        /// <summary>
        /// Method <c>HomepageShortcut</c> On key listener shortcut for going to the homepage
        /// </summary>
        private void HomepageShortcut(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Home) HomePagePictureBox_Click(this, e);
        }

        /// <summary>
        /// Method <c>HistoryShortcut</c> On key listener shortcut for displaying the hisotry
        /// </summary>
        private void HistoryShortcut(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.H) historyToolStripMenuItem.ShowDropDown();

        }


        /// <summary>
        /// Method <c>Browser_KeyUp</c> On key listener shortcut for making sure each of the shortcuts work when the
        /// main browser is the current view. 
        /// </summary>
        private void Browser_KeyUp(object sender, KeyEventArgs e)
        {
            GoBackShortcut(e);
            ReloadShortcut(e);
            HomepageShortcut(e);
            GoForwardShortcut(e);
            HistoryShortcut(e);
        }

        /// <summary>
        /// Method <c>OnFormClosing</c> Before closing the browser write all the favourite menu items and history menu items. 
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            FileManager.WriteFavouriteUrl(_favUrl);
            FileManager.WriteHistory(_historyManager);
            base.OnFormClosing(e);
        }
        
    }
}