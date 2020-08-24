using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class User
    {
        public string Token { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

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

                        var user = new User();

                        //Obtener datos de client y crear objeto user
                        user.Username = username;
                        user.Password = password;
                        user.Token = client.GetToken();
                        App.user = user;

                        if (recuerdame)
                        {
                            try
                            {
                                await SecureStorage.SetAsync("jwt_token", user.Token);
                            }
                            catch (Exception ex)
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
            Application.Current.Properties.Remove("token");
            App.user = null;
        }

    }
}
