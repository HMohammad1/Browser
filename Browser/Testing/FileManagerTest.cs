using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Browser.Testing
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void WriteReadHomepageTest()
        {
            FileManager.WriteStartupWebpage("https://google.com");

            var homepage = FileManager.ReadStartupWebpage();
            
            Assert.AreEqual("https://google.com", homepage);
        }
        
        [TestMethod]
        public void WriteReadHistoryTest()
        {
            var history = new HistoryManager();
            history.AddHistory("https://google.com");
            history.AddHistory("https://samsung.com");
            
            FileManager.WriteHistory(history);

            var history2 = new HistoryManager();
            FileManager.ReadHistory(history2);
            
            CollectionAssert.AreEqual(history.History, history2.History);
        }
        
        [TestMethod]
        public void WriteReadFavouriteTest()
        {
            var fav = new FavouriteUrl();
            var item1 = new FavouriteUrl();
            item1.Name = "Google";
            item1.Url = "https://google.com";
            fav.Favourite.Add(item1);
            
            FileManager.WriteFavouriteUrl(fav);

            var fav2 = new FavouriteUrl();
            FileManager.ReadFavouriteUrl(fav2);

            var name = fav2.Favourite[0].Name;
            var url = fav2.Favourite[0].Url;

            Assert.AreEqual(fav.Favourite[0].Name, name);
            Assert.AreEqual(fav.Favourite[0].Url, url);

        }
        
        [TestMethod]
        public void WriteReadBulkDownloadTest()
        {
            var download = new BulkDownloadManager();
            download.AddResult("200", 500, "https://google.com");
            download.DownloadTextFileName = "nameChanged";
            FileManager.WriteBulkDownload(download);

            var data = "";
            using (var reader = new StreamReader($"{Environment.ExpandEnvironmentVariables("%userprofile%/downloads/")}nameChanged.txt"))
            {
                data = reader.ReadLine();
            }

            Assert.AreEqual("200,500,https://google.com", data);

        }
    }
}