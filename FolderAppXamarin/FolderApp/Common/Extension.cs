using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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

        //Get avatar from uri if available or gravatar by default given url or username
        public static Image GetAvatarOrDefault(string url, string username)
        {
            Image image;
            if (!string.IsNullOrWhiteSpace(url) && !url.Contains("gravatar"))
            {
                image = new Image()
                {
                    Source = ImageSource.FromUri(new Uri(url))
                };
            }
            else
            {
                var urlString = ("https://ui-avatars.com/api/?name=" + username +
                    "&background=6f1850" +
                    "&rounded=true" +
                    "&color=FFFFFF").Replace(' ', '+');
                image = new Image()
                {
                    Source = ImageSource.FromUri(new Uri(urlString))
                };
            }
            return image;
        }
    }
}
