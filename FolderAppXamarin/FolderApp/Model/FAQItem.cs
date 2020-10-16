using Newtonsoft.Json;

namespace FolderApp.Model
{
    public class FAQItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
