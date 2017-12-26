using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace PayTheJarApi.JarTransactions
{
    public class JarTransaction
    {
        // ID = {JarId}::{TransactionId}
        [BsonId]
        [BsonElement("_Id")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("jarFoulEventId")]
        [JsonProperty("jarFoulEventId")]
        public ObjectId JarFoulEventId { get; set; }

        [BsonElement("payerUserId")]
        [JsonProperty("appUserId")]
        public ObjectId AppUserId { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }

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