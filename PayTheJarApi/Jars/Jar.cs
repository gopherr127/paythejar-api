using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace PayTheJarApi.Jars
{
    public class Jar
    {
        [BsonId]
        [BsonElement("id")]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("category")]
        [JsonProperty("category")]
        public string Category { get; set; }

        [BsonElement("currentAmount")]
        [JsonProperty("currentAmount")]
        public double CurrentAmount { get; set; }

        [BsonElement("createdDate")]
        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [BsonElement("createdBy")]
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
    }
}