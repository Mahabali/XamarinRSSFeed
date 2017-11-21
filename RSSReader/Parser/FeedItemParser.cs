using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using RSSReader.Model;

namespace RSSReader.Parser
{
    public class FeedItemParser
    {

        public FeedItemParser()
        {
        }

        public List<FeedItem> ParseFeed(string response)
        {
            if (response == null)
            {
                return null;
            }
  


            XDocument doc = XDocument.Parse(response);
            List<FeedItem> feeds = new List<FeedItem>();
            foreach (var item in doc.Descendants("item"))
            {
                FeedItem feed = new FeedItem();
                feed.title = item.Element("title").Value.ToString();
                feed.link = item.Element("link").Value.ToString();
                feed.description = item.Element("description").Value.ToString();
                feed.pubdate = item.Element("pubDate").Value.ToString();
                feed.guid = item.Element("guid").Value.ToString();
                feeds.Add(feed);
            }
            return feeds;
        }
    }
}
