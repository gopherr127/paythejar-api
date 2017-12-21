using MongoDB.Driver;

namespace PayTheJarApi.Jars
{
    public class JarContext : ContextBase
    {
        public IMongoCollection<Jar> Jars
        {
            get
            {
                return Database.GetCollection<Jar>("Jars");
            }
        }
    }
}