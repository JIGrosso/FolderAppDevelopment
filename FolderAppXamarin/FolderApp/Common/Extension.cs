using FolderApp;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        //Get value of "Description" tag from Enum
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return null; // could also return string.Empty
        }

        //Remove htmt content from string to show it as plain text
        public static string RemoveHtml(this string source)
        {

            //get rid of HTML tags
            var resultString = Regex.Replace(source, "<[^>]*>", string.Empty);


            return resultString;
        }


        //Remove htmt content from string to show it as plain text
        public static string RemoveParagraph(this string source)
        {

            //get rid of HTML tags
            var resultString = Regex.Replace(source, "<[^>]*p>", string.Empty);

            resultString = resultString.Trim();

            if (resultString.Length > 1)
            {
                resultString = resultString.Substring(0, resultString.Length);
            }

            resultString = Regex.Replace(resultString, "\n\n", "\n");

            return resultString;
        }

        //Get avatar from uri if available or gravatar by default given url or username
        public static Image GetAvatarOrDefault(string url, string username)
        {
            if (string.IsNullOrWhiteSpace(url) || url.Contains("gravatar"))
            {
                url = ("https://ui-avatars.com/api/?name=" + username +
                    "&background=6f1850" +
                    "&rounded=true" +
                    "&color=FFFFFF").Replace(' ', '+');
            }
            var image = new Image()
            {
                Source = new UriImageSource
                {
                    Uri = new Uri(url),
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(7, 0, 0, 0)
                }
            };
            return image;
        }

        //Get avatar from uri if available or gravatar by default given userId
        public static async Task<Image> GetAvatarOrDefault(int id)
        {
            var user = await App.client.WordPressClient.Users.GetByID(id, false, true);
            string username;
            if (string.IsNullOrEmpty(user.Name))
            {
                username = user.UserName;
            }
            else
            {
                username = user.Name;
            }
            return GetAvatarOrDefault(user.AvatarUrls.Size48, username);
        }
    }
}
