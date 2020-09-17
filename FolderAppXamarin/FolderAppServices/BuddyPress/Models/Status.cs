using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FolderAppServices.BuddyPress.Models
{
    //
    // Summary:
    //     Status of Activity
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        //
        // Summary:
        //     Publish
        Published = 0,
        //
        // Summary:
        //     Private
        Spam = 1,
    }
}
