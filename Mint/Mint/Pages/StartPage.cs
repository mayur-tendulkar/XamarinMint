using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mint.Pages
{
    public class StartPage : TabbedPage
    {
        public StartPage()
        {
            this.Children.Add(new ContactsPage());
            this.Children.Add(new LocationPage());
            this.Children.Add(new CameraPage());
        }
    }
}
