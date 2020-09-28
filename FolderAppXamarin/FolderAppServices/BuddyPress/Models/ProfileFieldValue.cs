using Newtonsoft.Json;

namespace FolderAppServices.BuddyPress.Models
{
    public class ProfileFieldValue
    {
        /// <summary>
        /// Rendered value
        /// </summary>
        [JsonProperty("rendered")]
        public string Rendered { get; set; }

        /// <summary>
        /// Raw value
        /// </summary>
        [JsonProperty("raw")]
        public object Raw { get; set; }

    }
}