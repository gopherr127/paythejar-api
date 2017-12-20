using MongoDB.Driver;

namespace PayTheJarApi.Jar
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