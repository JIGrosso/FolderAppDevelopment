using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FolderApp.Model
{
    public class User
    {
        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }


        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public static bool Login(string username, string password)
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(username);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if(isUsernameEmpty || isPasswordEmpty)
            {
                return false;
            }
            else
            {
                //Verifico los datos del usuario contra la BD. Obtengo el objeto usuario y debo verificar las password.

                //Simula la obtención del usuario de la BD
                var user = new User();
                user.Username = "Juani";
                user.Password = "asd";
                user.Token = "asdasfdsgnsern124123sfa";
                App.user = user;

                return true;
            }
        }

    }
}
