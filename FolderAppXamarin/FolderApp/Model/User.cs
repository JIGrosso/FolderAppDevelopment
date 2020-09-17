using FolderAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordPressPCL;
using Xamarin.Essentials;

namespace FolderApp.Model
{
    public class User
    {
        public string Token { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string CompleteName { get; set; }

        public string AvatarUrl { get; set; }

        public List<string> Roles { get; set; }

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
                        client.BuddyPressClient.SetJWToken(client.WordPressClient.GetToken());

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

        public static User GetUserFromClient(FolderWPClient client)
        {
            var user = new User();

            var wpClient = client.WordPressClient;

            //Obtener datos de client y crear objeto user
            var clientUser = wpClient.Users.GetCurrentUser().Result;
            //var user2 = client.Users.GetByID(clientUser.Id).Result;
            user.AvatarUrl = clientUser.AvatarUrls.Size48;
            user.Username = clientUser.UserName;
            user.Roles = (List<string>)clientUser.Roles;
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
