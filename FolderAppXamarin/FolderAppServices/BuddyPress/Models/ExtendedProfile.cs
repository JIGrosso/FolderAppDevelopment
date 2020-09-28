using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FolderAppServices.BuddyPress.Models
{
    public class ExtendedProfile
    {
        /// <summary>
        /// Member xProfile groups and its fields. view, edit
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("groups")]
        [JsonConverter(typeof(ExtendedProfileConverter))]
        public IEnumerable<ProfileGroup> Groups { get; set; }
    }

    public class ExtendedProfileConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented yet");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return string.Empty;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                JObject obj = JObject.Load(reader);
                var keys = obj.Properties();
                var groups = new List<ProfileGroup>();
                foreach(JProperty key in keys)
                {
                    var pg = (ProfileGroup) JsonConvert.DeserializeObject(key.Value.ToString(), typeof(ProfileGroup));
                    pg.Id = int.Parse(key.Name);
                    groups.Add(pg);
                }
                return groups;
            }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}