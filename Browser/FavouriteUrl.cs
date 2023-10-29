using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Browser
{
    /// <summary>This class deals with storing the favourite urls.
    /// <para>
    /// This class has been made serializable to allow it to convert to an xml file.
    /// </para>
    /// </summary>
    [Serializable]
    public class FavouriteUrl : ISerializable
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<FavouriteUrl> Favourite { get; set; }
        
        /// <summary>
        /// Method <c>FavouriteUrl</c> is used when needing to make a new entry in the favourites list. 
        /// </summary>
        public FavouriteUrl(string url, string name)
        {
            Url = url;
            Name = name;
            Favourite = new List<FavouriteUrl>();
        }

        /// <summary>
        /// Method <c>FavouriteUrl</c> is used on browser load to make the new favourites list to be populated. 
        /// </summary>
        public FavouriteUrl()
        {
            Favourite = new List<FavouriteUrl>();
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Url", Url);
            info.AddValue("Name", Name);
        }

        public FavouriteUrl(SerializationInfo info, StreamingContext context)
        {
            Url = (string)info.GetValue("Url", typeof(string));
            Name = (string)info.GetValue("Name", typeof(string));

        }
    }
}