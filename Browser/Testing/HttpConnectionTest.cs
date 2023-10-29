using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Browser.Testing
{
    [TestClass]
    public class HttpConnectionTest
    {
        [TestMethod]
        public void TestConnection200()
        {
            var code = "";
            var message = "";
            var fileSize = 0.0;
            
            var thread = new Thread(() =>
            {
                try
                {
                    var connection = new HttpConnection("https://samsung.com");
                    var html = connection.ReturnHtmlAsync().Result;
                    var htmlTitle = DisplayManager.UrlTitleField(html);

                    code = Convert.ToString(connection.StatusCode);
                    message = connection.ResponseMessage;
                    fileSize = connection.FileSize;
                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                }
            });

            thread.Start();
            thread.Join();
            Assert.AreEqual("200", code);
            Assert.AreEqual("OK", message);
            Assert.AreEqual(520311, fileSize);
        }
        
        [TestMethod]
        public void TestConnection400()
        {
            var code = "";
            var message = "";
            
            var thread = new Thread(() =>
            {
                try
                {
                    var connection = new HttpConnection("https://httpstat.us/400");
                    var html = connection.ReturnHtmlAsync().Result;
                    var htmlTitle = DisplayManager.UrlTitleField(html);

                    code = Convert.ToString(connection.StatusCode);
                    message = connection.ResponseMessage;
                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                }
            });

            thread.Start();
            thread.Join();
            Assert.AreEqual("400", code);
            Assert.AreEqual("Bad Request", message);
        }
        
        [TestMethod]
        public void TestConnection403()
        {
            var code = "";
            var message = "";
            
            var thread = new Thread(() =>
            {
                try
                {
                    var connection = new HttpConnection("https://httpstat.us/403");
                    var html = connection.ReturnHtmlAsync().Result;
                    var htmlTitle = DisplayManager.UrlTitleField(html);

                    code = Convert.ToString(connection.StatusCode);
                    message = connection.ResponseMessage;
                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                }
            });

            thread.Start();
            thread.Join();
            Assert.AreEqual("403", code);
            Assert.AreEqual("Forbidden", message);
        }
        
        [TestMethod]
        public void TestConnection404()
        {
            var code = "";
            var message = "";
            var thread = new Thread(() =>
            {
                try
                {
                    var connection = new HttpConnection("https://httpstat.us/404");
                    var html = connection.ReturnHtmlAsync().Result;
                    var htmlTitle = DisplayManager.UrlTitleField(html);

                    code = Convert.ToString(connection.StatusCode);
                    message = connection.ResponseMessage;
                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                }
            });

            thread.Start();
            thread.Join();
            Assert.AreEqual("404", code);
            Assert.AreEqual("Not Found", message);
        }

        [TestMethod]
        public void TestConnectionTitle()
        {
            var title = "";
            
            var thread = new Thread(() =>
            {
                try
                {
                    var connection = new HttpConnection("https://google.com");
                    var html = connection.ReturnHtmlAsync().Result;

                    title = DisplayManager.UrlTitleField(html);
                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                }
            });

            thread.Start();
            thread.Join();
            Assert.AreEqual("Before you continue to Google Search", title);
        }
        
        [TestMethod]
        public void TestConnectionTimeOut()
        {
            var message = "";
            var thread = new Thread(() =>
            {
                try
                {
                    var connection = new HttpConnection("https://httpstat.us/200?sleep=300000");
                    var html = connection.ReturnHtmlAsync().Result;
                    message = connection.ResponseMessage;                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                    message = "Task Cancelled: Took too long";
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                    message = "Invalid URL";
                }
                catch (TaskCanceledException e) when (e.InnerException is TimeoutException)
                {
                    message = "Task Cancelled, took too long to respond";
                }
            });
            thread.Start();
            thread.Join();
            Assert.AreEqual("Task Cancelled: Took too long", message);
        }
        
        [TestMethod]
        public void TestConnectionInvalidURL()
        {
            var message = "";
            var url = "https://httpstat,us";
            var thread = new Thread(() =>
            {
                if (url == "" || !DisplayManager.UrlChecker(url))
                {
                    message = "Invalid URL";
                    return;
                }
                
                try
                {
                    var connection = new HttpConnection(url);
                    var html = connection.ReturnHtmlAsync().Result;
                    message = connection.ResponseMessage;                }
                catch (AggregateException ae) when (ae.InnerException is TaskCanceledException)
                {
                    Console.WriteLine($"DisplayManager class task cancelled: {ae.Message}");
                    message = "Task Cancelled: Took too long";
                }
                catch (AggregateException ae) when (ae.InnerException is InvalidOperationException)
                {
                    Console.WriteLine($"DisplayManager class invalid operation: {ae.Message}");
                    message = "Invalid URL";
                }
                catch (TaskCanceledException e) when (e.InnerException is TimeoutException)
                {
                    message = "Task Cancelled, took too long to respond";
                }
            });
            thread.Start();
            thread.Join();
            Assert.AreEqual("Invalid URL", message);
        }
    }
}