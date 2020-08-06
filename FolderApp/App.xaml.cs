using FolderApp.Model;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System;
using WordPressPCL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp
{
    public partial class App : Application
    {
        public static WordPressClient client;

        public static User user = new User();

        public App()
        {
            InitializeComponent();

            client = new WordPressClient("http://192.168.100.14/wp-json/");

            try
            {
                var currentToken = (string) Application.Current.Properties["token"];
                if (currentToken != null)
                {
                    client.SetJWToken(currentToken);
                    if (client.IsValidJWToken().Result)
                    {
                        Current.MainPage = new MasterDetailPage()
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
            //MainPage = new MasterDetailPage()
            //{
            //    Master = new SideMenuDetail(),
            //    Detail = new NavigationPage(new LoginPage())
            //};

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
