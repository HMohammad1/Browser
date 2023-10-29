using System.Collections.Generic;

namespace Browser
{
    /// <summary>This class deals with downloading all the urls added to the bulk download feature.
    /// <para>
    /// This class uses a second class to store the results of the download as to separate this from the actual download
    /// class in case down the line new features want to be added and so less refactoring will need to be done.  
    /// </para>
    /// </summary>
    public class BulkDownloadManager
    {
        // Initialise the downloaded file name to bulk when no other is specified. 
        public string DownloadTextFileName { get; set; } = "bulk";
        public List<string> Files { get; set; } = new List<string>();
        public List<Results> Result { get; } = new List<Results>();

        /// <summary>
        /// Method <c>DeleteResults</c> Deletes all the urls are are currently stored. 
        /// </summary>
        public void DeleteResults()
        {
            Result.Clear();
        }

        /// <summary>
        /// Method <c>AddResult</c> Allows other classes to add a result to the inner class <c>Results</c>. 
        /// </summary>
        public void AddResult(string code, long fileSize, string url)
        {
            Result.Add(new Results(code, fileSize, url));
        }

        /// <summary>This class stores the results of the bulk download. 
        /// </summary>
        public class Results
        {
            public Results(string code, long fileSize, string url)
            {
                Code = code;
                FileSize = fileSize;
                Url = url;
            }

            public string Code { get; set; }
            public long FileSize { get; set; }
            public string Url { get; set; }
        }
    }
}