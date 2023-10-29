using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Browser
{
    /// <summary>This class deals with all the history and navigation to next and previous buttons.
    /// <para>
    /// This class has been made serializable to allow it to convert to an xml file. Indexes are used and updated to
    /// control going to next and previous pages. It follows the chrome style where if you have web pages to go forward
    /// but you navigate to a new url in the main url tab then yor forward webpages will be discarded and the new url
    /// typed in becomes the first item in the go forward list. 
    /// </para>
    /// </summary>
    [Serializable]
    public class HistoryManager : ISerializable
    {
        private int _backwardListIndex;
        private int _forwardListIndex;
        public List<string> History { get; set; } 
        private List<string> GoBackList { get; } 
        private List<string> GoForwardList { get; } 

        /// <summary>
        /// Method <c>HistoryManager</c> Needs to initialise the indexes to -1 so that when an item is added it can be
        /// set to 0 instead of 1 on the very first instance.
        /// </summary>
        public HistoryManager()
        {
            _backwardListIndex = -1;
            _forwardListIndex = -1;
            History =  new List<string>();
            GoBackList = new List<string>();
            GoForwardList = new List<string>();
        }

        /// <summary>
        /// Method <c>SetGoForwardList</c> Updates the list to go forward in the navigation. Need to add the new url
        /// at the start of the list each time.  
        /// </summary>
        private void SetGoForwardList(string url)
        {
            _forwardListIndex++;
            GoForwardList.Insert(0, url);
        }

        /// <summary>
        /// Method <c>SetGoBackwardList</c> Updates the list to go backward in the navigation. Need to add the new url
        /// at the end of the list each time.  
        /// </summary>
        public void SetGoBackwardList(string url)
        {
            _backwardListIndex++;
            GoBackList.Add(url);
        }

        /// <summary>
        /// Method <c>AddHistory</c> Adds the new history item to its variable <c>History</c>.
        /// </summary>
        public void AddHistory(string history)
        {
            History.Add(history);
        }

        /// <summary>
        /// Method <c>ResetForwardListIndex</c> Resets the forward list.
        /// </summary>
        public void ResetForwardListIndex()
        {
            _forwardListIndex = -1;
            GoForwardList.Clear();
        }

        /// <summary>
        /// Method <c>GoBack</c> As long as its possible to go back determined by <c>_backwardListIndex</c> not being -1
        /// it will add the current url via the <c>SetGoForwardList</c> method to the forward list and subsequently remove
        /// the previous item being navigated to from the <c>GoBackList</c>.
        /// </summary>
        public string GoBack(string currentUrl)
        {
            if (_backwardListIndex == -1) return null;
            SetGoForwardList(currentUrl);
            var temp = GoBackList[_backwardListIndex];
            GoBackList.RemoveAt(_backwardListIndex);
            _backwardListIndex--;
            return temp;
        }

        /// <summary>
        /// Method <c>GoForward</c> As long as its possible to go forward determined by <c>_forwardListIndex</c> not being -1
        /// it will add the current url via the <c>SetGoBackwardList</c> method to the backward list and subsequently remove
        /// the forward item being navigated to from the <c>GoForwardList</c>.
        /// </summary>
        public string GoForward(string currentUrl)
        {
            if (_forwardListIndex == -1) return null;
            SetGoBackwardList(currentUrl);
            var temp = GoForwardList[0];
            GoForwardList.RemoveAt(0);
            _forwardListIndex--;
            return temp;
        }

        /// <summary>
        /// Method <c>GetObjectData</c> Serializes the class to be exported. 
        /// </summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("History", History);
        }

        public HistoryManager(SerializationInfo info, StreamingContext context)
        {
            History = (List<string>)info.GetValue("Url", typeof(List<string>));
        }
    }
}