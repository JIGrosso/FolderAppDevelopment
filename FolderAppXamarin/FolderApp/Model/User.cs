﻿using System;
using System.Threading.Tasks;
using WordPressPCL;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class User
    {
        public string Token { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string CompleteName { get; set; }

        public string AvatarUrl { get; set; }

        public static async Task<bool> Login(string username, string password, bool recuerdame)
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
                    //JWT authentication
                    var client = App.client;
                    await client.RequestJWToken(username, password);
                    bool isValidToken = await client.IsValidJWToken();
                    if (isValidToken)
                    {
                        App.client = client;

                        App.User = GetUserFromClient(client);

                        if (recuerdame)
                        {
                            try
                            {
                                await SecureStorage.SetAsync("jwt_token", App.User.Token);
                            }
                            catch (Exception)
                            {
                                // Possible that device doesn't support secure storage on device.
                            }
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } catch(Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public static void Logout()
        {
            SecureStorage.Remove("jwt_token");
            App.User = null;
        }

        public static User GetUserFromClient(WordPressClient client)
        {
            var user = new User();

            //Obtener datos de client y crear objeto user
            var clientUser = client.Users.GetCurrentUser().Result;
            user.AvatarUrl = clientUser.AvatarUrls.Size48;
            user.Username = clientUser.UserName;
            user.Token = client.GetToken();

            if (string.IsNullOrEmpty(clientUser.Name))
            {
                user.CompleteName = user.Username;
            }
            else
            {
                user.CompleteName = clientUser.Name;
            }

            return user;
        }

    }
}
