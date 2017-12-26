using MongoDB.Driver;

namespace PayTheJarApi.JarTransactions
{
    public class JarTransactionContext : ContextBase
    {
        public IMongoCollection<JarTransaction> JarTransactions
        {
            get
            {
                return Database.GetCollection<JarTransaction>("JarTransactions");
            }
        }
    }
}