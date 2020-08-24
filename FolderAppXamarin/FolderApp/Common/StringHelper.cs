using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FolderApp.Common
{
    public class StringHelper
    {

        public static string RemoveHtml(string source)
        {

            //get rid of HTML tags
            var resultString = Regex.Replace(source, "<[^>]*>", string.Empty);


            return resultString;
        }

    }
}
