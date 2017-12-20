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

        [BsonElement("firstName")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        [JsonProperty("lastName")]
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