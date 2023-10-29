using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Browser
{
    /// <summary>This class deals with HttpClient and returns the raw html while updating the <c>ResponseMessage</c>,
    /// <c>StatusCode</c> and <c>FileSize</c> properties. 
    /// <para>
    /// Await is not used in this class as they are handled in the methods that use them via threads and background workers. 
    /// </para>
    /// </summary>
    public class HttpConnection
    {
        private readonly HttpClient _client;
        private readonly string _url;

        /// <summary>
        /// Method <c>HttpConnection</c> Initialises the connection with the url passed in and sets the timeout to 100 s.
        /// </summary>
        public HttpConnection(string url)
        {
            _client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(100)
            };
            _url = url;
        }

        public string ResponseMessage { get; private set; }
        public int StatusCode { get; private set; }
        public long FileSize { get; private set; }

        /// <summary>
        /// Method <c>ReturnHtmlAsync</c> Returns the html and all it's attributes that are needed.
        /// </summary>
        public async Task<string> ReturnHtmlAsync()
        {
            var page = "";
            try
            {
                if (_url == "")
                {
                    Console.WriteLine("HTTPConnection, ReturnedHTMLAsync: Url empty");
                    return page;
                }

                var response = await _client.GetAsync(_url);
                StatusCode = (int)response.StatusCode;
                ResponseMessage = response.ReasonPhrase;
                // Make sure that the response received is not empty so that a file size can be retrieved. 
                if (response.Content.Headers.ContentLength != null)
                    FileSize = response.Content.Headers.ContentLength.Value;

                // Display the according data depending on the status code retrieved. 
                if (response.StatusCode == HttpStatusCode.NotFound)
                    Console.WriteLine($"\"HTTPConnection, ReturnedHTMLAsync: HttpStatusCode.NotFound. Error status code: {(int)response.StatusCode}");
                else if (response.IsSuccessStatusCode)
                    page = await _client.GetStringAsync(_url);
                else
                    page = await _client.GetStringAsync(_url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\"HTTPConnection, ReturnedHTMLAsync: (first catch): {e.Message}");
            }
            catch (AggregateException ae) when (ae.InnerException is HttpRequestException)
            {
                Console.WriteLine($"\"HTTPConnection, ReturnedHTMLAsync (second cathch): {ae.InnerException.Message}");
            }
            // Task cancelled when HttpClient can't handle the request and instead cancels the task. 
            catch (TaskCanceledException e) when (e.InnerException is TimeoutException)
            {
                StatusCode = 0;
                ResponseMessage = "Task Cancelled, took too long to respond";
            }

            return page;
        }
    }
}