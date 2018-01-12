using MongoDB.Driver;
using System;
using System.Configuration;
using System.Security.Authentication;

namespace PayTheJarApi
{
    public class ContextBase
    {
        protected IMongoDatabase Database = null;

        public ContextBase()
        {
            string connectionString = ConfigurationManager.AppSettings["dbConnStr"];
            
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            if (mongoClient != null)
                Database = mongoClient.GetDatabase("PayTheJar");
        }
    }
}