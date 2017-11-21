using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using RSSReader.Model;
using RSSReader.Network;
using Xamarin.Forms;


namespace RSSReader.ViewModel
{
    public class RSSFeedViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<FeedItem> FeedList
        {
            get => feedList;
            set
            {
                if (feedList != value){
                    feedList = value;
                    OnPropertyChanged("FeedList");   
                }

            }
        }

        private FeedItem selectedItem = null;
        private INavigation Navigation;
        public FeedItem SelectedItem
        {
            get => selectedItem;
            set
            {
                if(selectedItem != value){
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");  
                    OpenWebPage();
                }
            }
        }
        ObservableCollection<FeedItem> feedList = null;
        public event PropertyChangedEventHandler PropertyChanged;

        public RSSFeedViewModel(INavigation navigation)
        {
            this.GetNewsFeedAsync();
            Navigation = navigation;
        }

        public async void GetNewsFeedAsync()
        {
            NetworkManager manager = NetworkManager.Instance;
            List<FeedItem> list = await manager.GetSyncFeedAsync();
            FeedList = new ObservableCollection<FeedItem>(list);
        }

        protected  void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenWebPage(){
            WebPage page = new WebPage(selectedItem.guid);
            Navigation.PushAsync(page);
        }
    }
}
