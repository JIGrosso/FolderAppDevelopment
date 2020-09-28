using Newtonsoft.Json;

namespace FolderAppServices.BuddyPress.Models
{
    public class ProfileField
    {
        /// <summary>
        /// A unique numeric ID for the profile field. Read only
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        public int Id { get; set; }

        /// <summary>
        /// The name of the profile field.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The name of the profile field.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("value")]
        public ProfileFieldValue Value { get; set; }
    }
}