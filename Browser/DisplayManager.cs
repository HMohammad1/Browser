using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    /// <summary>
    /// Delegate <c>InitialiseHtml</c> is used to run the <c>DisplayManager</c> method so that the method signature
    /// can change without needing to change the signature everywhere. 
    /// </summary>
    public delegate void InitialiseHtml(TextBox url, RichTextBox rawHtml, TextBox code, TextBox message, TextBox title);

    /// <summary>This class deals with displaying all the visuals unless they require an onClick delegate.
    /// <para>
    /// This is an abstract class as it should only contain static methods since it's purpose is to display
    /// content without inherently needing to be instantiated. It's main use is within the <c>Browser</c> class to
    /// update menus, render new forms and retrieve the html from urls.  
    /// </para>
    /// </summary>
    public abstract class DisplayManager
    {
        /// <summary>
        /// Method <c>UrlChecker</c> Returns true if the url entered is valid using the Uri class. 
        /// </summary>
        public static bool UrlChecker(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uriResult) || uriResult == null) return false;
            return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
        }

        /// <summary>
        /// Method <c>DisplayHtml</c> Renders the main view by displaying the raw html, status code, response message
        /// and the title of the website as returned by the <c>Title</c> field inside the html by calling the
        /// <c>HTTPConnection</c> class. 
        /// </summary>
        public static void DisplayHtml(TextBox url, RichTextBox rawHtml, TextBox code, TextBox message, TextBox title)
        {
            // While this is running don't allow the url to be changed
            url.Invoke((Action)(() => { url.ReadOnly = true; }));
            if (url.Text == "" || !UrlChecker(url.Text))
            {
                Console.WriteLine("Url empty: file manager)");
                url.Invoke((Action)(() => { url.ReadOnly = false; ClearBoxes(rawHtml, code, message, title); message.AppendText("Invalid URL");}));
                return;
            }

            try
            {
                var connection = new HttpConnection(url.Text);
                var html = connection.ReturnHtmlAsync().Result;
                var htmlTitle = UrlTitleField(html);
                // BeginInvoke allows the ui thread to be accessed from another thread to allow the data to be written
                rawHtml.BeginInvoke((Action)(() =>
                {
                    ClearBoxes(rawHtml, code, message, title);
                    rawHtml.AppendText(html);
                    code.AppendText(Convert.ToString(connection.StatusCode));
                    title.AppendText(htmlTitle);
                    message.AppendText(connection.ResponseMessage ?? "ERR_CONNECTION_TIMED_OUT");
                }));
            }
            catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
            {
                Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                DisplayExceptionError(rawHtml, code, message, title, "Task Cancelled: Took too long");
            }
            catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
            {
                Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                DisplayExceptionError(rawHtml, code, message, title, "Invalid URL");
            }
            url.Invoke((Action)(() => { url.ReadOnly = false; }));
        }


        /// <summary>
        /// Method <c>DisplayExceptionError</c> Displays the errors of the catch when running <c>DisplayHtml</c> method
        /// </summary>
        private static void DisplayExceptionError(RichTextBox source, TextBox code, TextBox message, TextBox title,
            string error)
        {
            message.BeginInvoke((Action)(() =>
            {
                ClearBoxes(source, code, message, title);

                message.AppendText(error);
            }));
        }

        /// <summary>
        /// Method <c>ClearBoxes</c> Clears the items currently in the main view when <c>DisplayHtml</c> method requires
        /// it. 
        /// </summary>
        private static void ClearBoxes(RichTextBox source, TextBox code, TextBox message, TextBox title)
        {
            source.Clear();
            code.Clear();
            message.Clear();
            title.Clear();
        }

        /// <summary>
        /// Method <c>ChangeUrl</c> Displays the form to change the home page url.
        /// </summary>
        public static void ChangeUrl()
        {
            Form form = new ChangeUrlForm();

            form.ShowDialog();
        }

        /// <summary>
        /// Method <c>AddFavouriteUrl</c> Displays the form to add a new favourite url. 
        /// </summary>
        public static void AddFavouriteUrl(FavouriteUrl url, ToolStripMenuItem item, Browser b, string currentUrl)
        {
            Form form = new AddFavouriteForm(url, item, b, currentUrl);
            form.ShowDialog();
        }

        /// <summary>
        /// Method <c>UrlTitleField</c> Returns the title of the website from the raw html passed in. 
        /// </summary>
        public static string UrlTitleField(string page)
        {
            const string pattern = @"<title>([^<]+)<\/title>";
            var match = Regex.Match(page, pattern);
            return match.Groups[1].Value;
        }

        /// <summary>
        /// Method <c>EditFavouriteUrl</c> Displays the form to edit a favourite url that has previously been added. 
        /// </summary>
        public static void EditFavouriteUrl(FavouriteUrl url, ToolStripMenuItem item, Browser b, FavouriteUrl selected,
            ToolStripMenuItem clickedItem)
        {
            Form form = new AddFavouriteForm(url, item, b, selected, clickedItem);
            form.Text = "Edit URL";
            form.ShowDialog();
        }

        /// <summary>
        /// Method <c>SpecifyDownloadFileName</c> Displays the form to change the filename of the bulk download feature. 
        /// </summary>
        public static void SpecifyDownloadFileName(BulkDownloadManager download)
        {
            Form form = new BulkDownloadFilename(download);
            form.ShowDialog();
        }

        /// <summary>
        /// Method <c>AddNewDownloadUrl</c> Displays the form to add a new url to be downloaded by the bulk download. 
        /// </summary>
        public static void AddNewDownloadUrl(BulkDownloadManager download, Browser b, ToolStripMenuItem menuItem)
        {
            Form form = new BulkDownloadAddUrl(download, b, menuItem);
            form.ShowDialog();
        }

        /// <summary>
        /// Method <c>DownloadItems</c> Download all the items currently added to the bulk download and displays the result. 
        /// </summary>
        public static void DownloadItems(BulkDownloadManager download, TextBox url, RichTextBox display)
        {
            if (download.Files.Count == 0) return;

            // Run it on a new thread as to not block the UI thread. 
            var thread = new Thread(() =>
            {
                url.Invoke((Action)(() => { url.ReadOnly = true; }));
                foreach (var i in download.Files)
                    try
                    {
                        var connection = new HttpConnection(i);
                        // This needs to be run in order to populate the status code, response message and file size fields. 
                        var html = connection.ReturnHtmlAsync().Result;

                        if (connection.ResponseMessage != null)
                            // Add all the results obtained to a list
                            download.AddResult(connection.StatusCode.ToString(), connection.FileSize, i);
                        else
                            download.AddResult("ERR_CONNECTION_TIMED_OUT", 0, i);
                    }
                    catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                    {
                        Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                    }
                    catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                    {
                        Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                    }

                url.Invoke((Action)(() => { url.ReadOnly = false; }));
                
                // Display the results of each url downloaded
                display.BeginInvoke((Action)(() =>
                {
                    display.Clear();
                    foreach (var result in download.Result)
                    {
                        display.AppendText(
                            $"Code: {result.Code}, FileSize: {result.FileSize} bytes, URL: {result.Url}" +
                            Environment.NewLine);
                        Console.WriteLine(Environment.CurrentDirectory);
                    }
                }));

                // Write the results to the text file
                FileManager.WriteBulkDownload(download);
                // Show where the results are stored, Environment.CurrentDirectory will get the current working directory. 
                MessageBox.Show(
                    $"File downloaded to {Environment.ExpandEnvironmentVariables("%userprofile%/downloads/")}{download.DownloadTextFileName}.txt");
            });

            thread.Start();
            // Make sure to delete the stored results so they are not downloaded again on top of the new downloaded added. 
            download.DeleteResults();
        }
    }
}