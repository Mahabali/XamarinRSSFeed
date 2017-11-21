using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Foundation;
using UIKit;

namespace RSSReader.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());
            this.UntrustedCertificateWorkAround();
            return base.FinishedLaunching(app, options);
        }

        private void UntrustedCertificateWorkAround(){
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
        }
    }
}
