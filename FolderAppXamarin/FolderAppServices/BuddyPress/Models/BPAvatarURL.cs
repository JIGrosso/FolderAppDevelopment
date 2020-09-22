using Newtonsoft.Json;

namespace FolderAppServices.BuddyPress.Models
{
    public class BPAvatarURL
    {
        /// <summary>
        /// Full size of the image file. Read only
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("full")]
        public string Full { get; set; }

        /// <summary>
        /// Thumb size of the image file. Read only
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("thumb")]
        public string Thumb { get; set; }
    }
}