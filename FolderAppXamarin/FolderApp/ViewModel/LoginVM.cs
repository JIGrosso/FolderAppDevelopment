using FolderApp.Model;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RecuerdameChecked { get; set; } = false;

        private bool activityViewVisible { get; set; }
        public bool ActivityViewVisible
        {
            get
            {
                return activityViewVisible;
            }
            set
            {
                activityViewVisible = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ActivityViewVisible)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Login()
        {
            ActivityViewVisible = true;

            bool loginSuccess = await User.Login(Username, Password, RecuerdameChecked);

            ActivityViewVisible = false;

            if (loginSuccess)
            {

                App.Current.MainPage = new MasterDetailPage()
                {
                    Master = new SideMenuMaster(),
                    Detail = new NavigationPage(new HomePage())
                };
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or password are incorrect", "Ok");
            }
        }



    }
}
