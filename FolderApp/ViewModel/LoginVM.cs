using FolderApp.Model;
using FolderApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using Xamarin.Essentials;

namespace FolderApp.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private User user;

        public User User
        {
            get { return user; }
            set 
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

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


        public LoginVM()
        {
            User = new User();
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
            bool loginSuccess = await User.Login(User.Username, User.Password);

            if(loginSuccess)
            {
                await App.Current.MainPage.Navigation.PushAsync(new NoticiasPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or password are incorrect", "Ok");
            }
        }



    }
}
