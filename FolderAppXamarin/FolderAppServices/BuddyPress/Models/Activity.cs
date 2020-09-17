using Newtonsoft.Json;
using System;

namespace FolderAppServices.BuddyPress.Models
{
    public class Activity : Base
    {
        /// <summary>
        /// The date the object was published, in the site's timezone.
        /// </summary>
        /// <remarks>Context: view, edit, embed</remarks>
		[JsonProperty("date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Whether the activity has been marked as spam or not.
        /// </summary>
        /// <remarks>
        /// Read only
        /// Context: view, edit
        /// One of: published, spam
        /// </remarks>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// Type of Post for the object.
        /// </summary>
        /// <remarks>
        /// Read only
        /// Context: view, edit, embed
        /// </remarks>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The title for the object.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// URL to the object.
        /// </summary>
        /// <remarks>
        /// Read only
        /// Context: view, edit
        /// </remarks>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// The content for the object.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("content")]
        public WordPressPCL.Models.Content Content { get; set; }

        /// <summary>
        /// The ID for the author of the object.
        /// </summary>
        /// <remarks>Context: view, edit, embed</remarks>
        [JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int UserId { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public Activity()
        {
        }
    }
}

