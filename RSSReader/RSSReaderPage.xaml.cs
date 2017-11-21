using System.Collections.Generic;
using RSSReader.Model;
using RSSReader.ViewModel;
using Xamarin.Forms;

namespace RSSReader
{
    public partial class RSSReaderPage : ContentPage
    {
        RSSFeedViewModel RSSFeedViewModelObject;
     
        public RSSReaderPage()
        {
            InitializeComponent();

            RSSFeedViewModelObject = new RSSFeedViewModel(Navigation);


            Title = "RSS Feeds";
            BindingContext = RSSFeedViewModelObject;
        }

       


    }
}
