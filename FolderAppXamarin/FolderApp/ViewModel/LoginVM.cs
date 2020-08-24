using FolderApp.Model;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        public User User { get; set; }

        private string username;

        public string Username
        {
            get { return username; }
            set 
            { 
                username = value;
                User = new User()
                {
                    Username = this.Username,
                    Password = this.Password
                };
                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            { 
                password = value;
                User = new User()
                {
                    Username = this.Username,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }

        public bool RecuerdameChecked { get; set; }


        public LoginVM()
        {
            User = new User();
            RecuerdameChecked = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async void Login()
        {
            bool loginSuccess = await User.Login(User.Username, User.Password, RecuerdameChecked);

            if(loginSuccess)
            {

                App.Current.MainPage = new MasterDetailPage()
                {
                    Master = new SideMenuMaster(),
                    Detail = new NavigationPage(new NoticiasPage())
                };
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or password are incorrect", "Ok");
            }
        }



    }
}
