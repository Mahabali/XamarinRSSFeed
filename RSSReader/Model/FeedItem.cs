using System;
namespace RSSReader.Model
{
    public class FeedItem
    {
   
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string pubdate { get; set; }
        public string guid { get; set; }

        public FeedItem()
        {
        }
    }
}
