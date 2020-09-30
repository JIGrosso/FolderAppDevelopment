using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Net.Http;
using Xamarin.Forms;
using static ExtensionMethods.MyExtensions;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq;
using FolderAppServices.BuddyPress.Models;

namespace FolderApp.Model
{
    public class User
    {
        public string Token { get; set; }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string CompleteName { get; set; }

        public string AvatarUrl { get; set; }

        public string Email { get; set; }

        public string Birthday { get; set; }

        public string FechaIngreso { get; set; }

        public string SkypeId { get; set; }

        public List<string> Roles { get; set; }

        public string Celular { get; set; }

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

                        var userTask = GetUserFromClient();

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

                        App.User = await userTask;

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

        public static async Task<User> GetUserFromClient()
        {
            var user = new User();

            var wpClient = App.client.WordPressClient;
            var bpClient = App.client.BuddyPressClient;

            //Ejecutar tasks asincronicamente
            var wpUserTask = GetWpUser();
            var bpUserTask = bpClient.Members.GetCurrentMember();
            var tasks = new List<Task> { wpUserTask, bpUserTask };

            while(tasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny(tasks);
                if(finishedTask == wpUserTask)
                {
                    //Obtener datos de wordpress y ejecutar task de avatar
                    var wpUser = await (finishedTask as Task<WordPressPCL.Models.User>);

                    user.Id = wpUser.Id;
                    user.Roles = (List<string>)wpUser.Roles;
                    user.Email = wpUser.Email;
                    user.Token = App.client.GetToken();

                    var avatarTask = bpClient.Members.GetUserAvatars(user.Id);
                    user.AvatarUrl = (await avatarTask).Full;
                } else if (finishedTask == bpUserTask)
                {
                    var bpUser = await (finishedTask as Task<Member>);
                    user.Username = bpUser.UserLogin;
                    user.Birthday = bpUser.ExtendedProfile.Groups.Where(x => x.Name == "Datos Personales").SingleOrDefault()
                       .Fields.Where(x => x.Name == "Fecha de Nacimiento").SingleOrDefault().Value.Rendered.RemoveParagraph();
                    user.FechaIngreso = bpUser.ExtendedProfile.Groups.Where(x => x.Name == "Datos Personales").SingleOrDefault()
                        .Fields.Where(x => x.Name == "Fecha de Ingreso").SingleOrDefault().Value.Rendered.RemoveParagraph();
                    user.SkypeId = (string)bpUser.ExtendedProfile.Groups.Where(x => x.Name == "Datos Personales").SingleOrDefault()
                        .Fields.Where(x => x.Name == "Skype ID").SingleOrDefault().Value.Raw;
                    user.Celular = (string)bpUser.ExtendedProfile.Groups.Where(x => x.Name == "Datos Personales").SingleOrDefault()
                        .Fields.Where(x => x.Name == "Celular").SingleOrDefault().Value.Raw;

                    user.CompleteName = string.IsNullOrEmpty(bpUser.Name) ? bpUser.UserLogin : bpUser.Name;
                }
                tasks.Remove(finishedTask);
            }

            return user;
        }

        //STATIC Get user thumbnail given UserId
        public static async Task<Image> GetUserThumbnail(int id)
        {
            return await GetAvatarOrDefault(id);
        }

        //Get user thumbnail for User instance
        public Task<Image> GetUserThumbnail()
        {
            return Task.Run( () => GetAvatarOrDefault(AvatarUrl, CompleteName));
        }
        
        public static async Task<WordPressPCL.Models.User> GetWpUser()
        {
            var wpClient = App.client.WordPressClient;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", wpClient.GetToken());
            var response = await client.GetAsync($"{wpClient.WordPressUri}wp/v2/users/me?context=edit");

            var responseString = await response.Content.ReadAsStringAsync();
            
            var user = JsonConvert.DeserializeObject<WordPressPCL.Models.User>(responseString);
            
            return user;
        }
    }
}