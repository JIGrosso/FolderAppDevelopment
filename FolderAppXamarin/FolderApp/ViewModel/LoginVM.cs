using FolderApp.Model;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System.ComponentModel;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    public class LoginVM
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RecuerdameChecked { get; set; } = false;

        public async void Login()
        {
            bool loginSuccess = await User.Login(Username, Password, RecuerdameChecked);

            if(loginSuccess)
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
