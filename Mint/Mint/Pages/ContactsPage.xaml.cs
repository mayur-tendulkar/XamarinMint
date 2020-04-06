using Mint.Model;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mint.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
            if (Device.RuntimePlatform == Device.Android)
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Contacts);
                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Contacts);
                    if (results[Permission.Contacts] == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                    {
                        LoadContacts();
                    }
                }
                else
                {
                    LoadContacts();
                }
            }
            else
            {
                LoadContacts();
            }
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {

        }
        protected async void LoadContacts()
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            var contacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();
            var listView = from x in contacts
                           orderby x.Name
                           select new ContactModel()
                           {
                               Name = x.Name,
                               Email = x.Email,
                               Emails = x.Emails,
                               PhoneNumber = x.Number,
                               PhoneNumbers = x.Numbers,
                               ContactedYet = false,
                               ReferredBy = Preferences.Get("USER_NAME", "NOT_AVAILABLE")
                           };

            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;

            ContactList.ItemsSource = listView;
        }
    }
}