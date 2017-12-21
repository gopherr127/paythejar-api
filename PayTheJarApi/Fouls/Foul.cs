using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace PayTheJarApi.Fouls
{
    public class Foul
    {
        [BsonId]
        [BsonElement("id")]
        [JsonProperty("id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [BsonElement("penaltyAmount")]
        [JsonProperty("penaltyAmount")]
        public double PenaltyAmount { get; set; }
    }
}