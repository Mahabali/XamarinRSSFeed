using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Connectivity;
using RSSReader.Model;
using RSSReader.Parser;

namespace RSSReader.Network
{
    public sealed class NetworkManager
    {
        public static NetworkManager network_manager = new NetworkManager();
        public static string network_url = "http://feeds.sciencedaily.com/sciencedaily?format=xml";
        private NetworkManager()
        {
        }

        public static NetworkManager Instance
        {
            get
            {
                return network_manager;
            }
        }

        public async Task<List<FeedItem>> GetSyncFeedAsync()
        {
            if (this.IsConnected())
            {
                Uri uri = new Uri(network_url);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);
                String response_string = await response.Content.ReadAsStringAsync();
                FeedItemParser parser = new FeedItemParser();
               // List<FeedItem> list = await Task.Run(() => parser.ParseFeed(response_string));
                List<FeedItem> list = await Task.Run(() => parser.ParseFeed(response_string));
                return list;
            }
            return null;
        }

        public bool IsConnected(){
            if (CrossConnectivity.Current.IsConnected){
                return true;
            }
            return false;
        }
    }
}
