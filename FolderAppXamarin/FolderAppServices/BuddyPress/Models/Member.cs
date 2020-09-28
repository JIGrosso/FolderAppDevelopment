using Newtonsoft.Json;

namespace FolderAppServices.BuddyPress.Models
{
    public class Member : Base
    {
        /// <summary>
        /// Display name for the member.
        /// </summary>
        /// <remarks>Context: embed, view, edit</remarks>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The name used for that user in @-mentions.
        /// </summary>
        /// <remarks>Context: embed, view, edit</remarks>
        [JsonProperty("mention_name")]
        public string MentionName { get; set; }

        /// <summary>
        /// Profile URL of the member.
        /// </summary>
        /// <remarks>Context: embed, view, edit</remarks>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the member.
        /// </summary>
        /// <remarks>Context: embed, view, edit</remarks>
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        /// <summary>
        /// Roles assigned to the member.
        /// </summary>
        /// <remarks>Context: edit</remarks>
        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        /// <summary>
        /// Avatar URLs for the member (Full & Thumb sizes).
        /// </summary>
        /// <remarks>Context: embed, view, edit</remarks>
        [JsonProperty("avatar_urls")]
        public BPAvatarURL AvatarURLs { get; set; }

        /// <summary>
        /// Member xProfile groups and its fields. view, edit
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("xprofile")]
        public ExtendedProfile ExtendedProfile { get; set; }
    }
}
