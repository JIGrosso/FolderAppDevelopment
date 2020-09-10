using FolderApp.Model;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using WordPressPCL;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FolderApp
{
    public partial class App : Application
    {
        public static WordPressClient client;

        public static User User = new User();

        public App()
        {
            InitializeComponent();

            client = new WordPressClient("https://intranet.folderit.net/wp-json/");

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
                            Detail = new NavigationPage(new NoticiasPage())
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
