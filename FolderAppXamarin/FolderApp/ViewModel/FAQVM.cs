using FolderApp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderApp.ViewModel
{
    public class FAQVM
    {
        public List<FAQItem> FaqItems { get; set; }

        public FAQVM()
        {
            Task<List<FAQItem>> itemsTask = Task.Run(async () => await GetItems());
            FaqItems = itemsTask.Result;
        }

        private async static Task<List<FAQItem>> GetItems()
        {
            var faqsContent = await App.client.WordPressClient.Pages.GetByID(63);
            return ParseStringContent(faqsContent.Content.Rendered);
        }

        private static List<FAQItem> ParseStringContent(string responseString)
        {
            string regex = "\\[vc_row\\]\\[vc_column\\]";

            string result = Regex.Replace(responseString, regex, "[");

            regex = "\\[vc_toggle title=»";

            result = Regex.Replace(result, regex, "{\"title\":\"");

            regex = "» color=.+\\]";

            result = Regex.Replace(result, regex, "\",\"content\":\"");

            regex = "\\[/vc_toggle\\]";

            result = Regex.Replace(result, regex, "\"},");

            regex = "\\[/vc_column\\]\\[/vc_row\\]";

            result = Regex.Replace(result, regex, "]");

            result = result.Substring(3, result.Length - 8);

            regex = "<a href=\"";

            result = Regex.Replace(result, regex, "<a href=\\\"");

            regex = "\">";

            result = Regex.Replace(result, regex, "\\\">");

            regex = "style=\"";

            result = Regex.Replace(result, regex, "style=\\\"");

            List<FAQItem> faqList = (List<FAQItem>)JsonConvert.DeserializeObject<IList<FAQItem>>(result);

            return faqList;
        }
    }
}
