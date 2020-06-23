using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;

namespace FolderApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private string token;

        public string Token
        {
            get { return token; }
            set
            {
                token = value;
                OnPropertyChanged("Token");
            }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
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
                OnPropertyChanged("Password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public static async Task<bool> Login(string username, string password)
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(username);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if(isUsernameEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {           
                try
                {
                    // JWT authentication
                    //var client = new WordPressClient("http://192.168.0.7:8080/wp-json/");
                    //client.AuthMethod = AuthMethod.JWT;
                    //await client.RequestJWToken(username, password);
                    //var isValidToken = await client.IsValidJWToken();
                    //if (isValidToken)
                    //{
                    //    App.client = client;

                        var user = new User();

                        //Obtener datos de client y crear objeto user
                        user.Username = "Juani";
                        user.Password = "asd";
                        user.Token = "asdasfdsgnsern124123sfa";
                        App.user = user;

                        return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                } catch(Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
