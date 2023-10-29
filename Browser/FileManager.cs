using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Browser
{
    /// <summary>This class deals with all the file writes and reads.
    /// <para>
    /// Files are transformed into xml when writing to the file system with the exception being
    /// the homepage url where that is stored in a text file. Serialisation is used to make the xml files
    /// and then de serialised when reading back in. It is an abstract class as it should not be instantiated but
    /// rather kept static. 
    /// </para>
    /// </summary>
    public abstract class FileManager
    {
        /// <summary>
        /// Method <c>WriteStartupWebpage</c> Writes the homepage set in the browser session to a text file.
        /// </summary>
        public static void WriteStartupWebpage(string url)
        {
            try
            {
                using (var writer = new StreamWriter("Files\\home_page.txt"))
                {
                    writer.Write(url);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("FileManager, WriteStartupWebpage error: " + e.Message);
            }
        }

        /// <summary>
        /// Method <c>WriteFavouriteUrl</c> Writes all the favourite urls set in the browser session to a xml file.
        /// </summary>
        public static void WriteFavouriteUrl(FavouriteUrl url)
        {
            using (Stream fs = new FileStream("Files\\fav_url.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var serializer = new XmlSerializer(typeof(List<FavouriteUrl>));
                serializer.Serialize(fs, url.Favourite);
            }
        }

        /// <summary>
        /// Method <c>WriteHistory</c> Writes all the history set in the browser session to a xml file.
        /// </summary>
        public static void WriteHistory(HistoryManager history)
        {
            using (Stream fs = new FileStream("Files\\history.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(fs, history.History);
            }
        }

        /// <summary>
        /// Method <c>ReadHistory</c> Reads all the history from the xml file into its variable to be displayed.
        /// </summary>
        public static void ReadHistory(HistoryManager history)
        {
            if (!File.Exists("Files\\history.xml")) return;
            using (var fs = File.OpenRead("Files\\history.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                history.History = (List<string>)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Method <c>ReadFavouriteUrl</c> Reads all the favourite urls from the xml file into its variable to be displayed.
        /// </summary>
        public static void ReadFavouriteUrl(FavouriteUrl favouriteUrl)
        {
            if (!File.Exists("Files\\fav_url.xml")) return;
            var serializer = new XmlSerializer(typeof(List<FavouriteUrl>));
            using (var fs = File.OpenRead("Files\\fav_url.xml"))
            {
                favouriteUrl.Favourite = (List<FavouriteUrl>)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Method <c>ReadStartupWebpage</c> Reads the startup webpage to be displayed when the browser first loads up.
        /// </summary>
        public static string ReadStartupWebpage()
        {
            string startUpUrl;
            using (var reader = new StreamReader("Files\\home_page.txt"))
            {
                startUpUrl = reader.ReadLine();
            }

            return startUpUrl;
        }

        /// <summary>
        /// Method <c>WriteBulkDownload</c> Writes all the items to be downloaded to a text file chosen by the user.
        /// </summary>
        public static void WriteBulkDownload(BulkDownloadManager bulkDownloadManager)
        {
            var fileName = bulkDownloadManager.DownloadTextFileName;
            var results = bulkDownloadManager.Result;
            try
            {
                using (var writer = new StreamWriter($"{Environment.ExpandEnvironmentVariables("%userprofile%/downloads/")}{fileName}.txt"))
                {
                    foreach (var i in results) writer.WriteLine($"{i.Code},{i.FileSize},{i.Url}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FileManager, WriteBulkDownload error: " + e.Message);
            }
        }
    }
}