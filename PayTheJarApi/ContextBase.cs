using MongoDB.Driver;
using System.Security.Authentication;

namespace PayTheJarApi
{
    public class ContextBase
    {
        protected IMongoDatabase Database = null;

        public ContextBase()
        {
            string connectionString =
                @"mongodb://paythejar:mTsgccwX3W7pAzJSHgmbtGzlQR0BV9Igr174ZBENd3Su0gyCLnQGuIgQvAgSAY3bVf9RWYbvmAXdcRmVCHbR3Q==@paythejar.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            if (mongoClient != null)
                Database = mongoClient.GetDatabase("PayTheJar");
        }
    }
}