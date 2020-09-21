using FolderApp.Model;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using FolderAppServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FolderApp
{
    public partial class App : Application
    {
        public static FolderWPClient client;

        public static User User = new User();

        public static ObservableCollection<Activity> ActivitiesCache = new ObservableCollection<Activity>();

        public App()
        {
            InitializeComponent();

            client = new FolderWPClient();

            try
            {
                var currentToken = SecureStorage.GetAsync("jwt_token").Result;
                if (currentToken != null)
                {
                    client.SetJWToken(currentToken);
                    if (client.IsValidJWToken().Result)
                    {

                        User = User.GetUserFromClient(client);

                        Current.MainPage = new MainView()
                        {
                            Master = new SideMenuMaster(),
                            Detail = new NavigationPage(new HomePage())
                        };

                        return;
                    }
                }

                MainPage = new LoginPage();
            }
            catch
            {
                MainPage = new LoginPage();
            }

       }
    }
}
