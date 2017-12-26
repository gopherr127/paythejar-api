using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace PayTheJarApi.JarFoulEvents
{
    public class JarFoulEvent
    {
        // ID = Jar ID
        [BsonId]
        [BsonElement("id")]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        [BsonElement("foulId")]
        [JsonProperty("foulId")]
        public ObjectId FoulId { get; set; }

        [BsonElement("committedByUserId")]
        [JsonProperty("committedByUserId")]
        public ObjectId CommittedByUserId { get; set; }

        [BsonElement("committedOnDate")]
        [JsonProperty("committedOnDate")]
        public string CommittedOnDate { get; set; }
    }
}