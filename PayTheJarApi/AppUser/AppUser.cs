using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace PayTheJarApi.AppUser
{
    public class AppUser
    {
        [BsonId]
        [BsonElement("id")]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        [BsonElement("username")]
        [JsonProperty("username")]
        public string UserName { get; set; }

        [BsonElement("firstname")]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [BsonElement("avatarUrl")]
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [BsonElement("registrationDate")]
        [JsonProperty("registrationDate")]
        public string RegistrationDate { get; set; }

        [BsonElement("location")]
        [JsonProperty("location")]
        public string Location { get; set; }
    }
}