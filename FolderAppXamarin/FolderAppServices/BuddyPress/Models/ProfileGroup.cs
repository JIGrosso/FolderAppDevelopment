using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FolderAppServices.BuddyPress.Models
{
    public class ProfileGroup
    {
        /// <summary>
        /// A unique numeric ID for the group of profile fields. Read only.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        public int Id { get; set; }

        /// <summary>
        /// The name of the group of profile fields.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The list of profile fields object attached to the group of profile fields.
        /// </summary>
        /// <remarks>Context: view, edit</remarks>
        [JsonProperty("fields")]
        [JsonConverter(typeof(ExtendedProfileFieldsConverter))]
        public IEnumerable<ProfileField> Fields { get; set; }
    }

    public class ExtendedProfileFieldsConverter : JsonConverter
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
                var fields = new List<ProfileField>();
                foreach (JProperty key in keys)
                {
                    var pf = (ProfileField)JsonConvert.DeserializeObject(key.Value.ToString(), typeof(ProfileField));
                    pf.Id = int.Parse(key.Name);
                    fields.Add(pf);
                }
                return fields;
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