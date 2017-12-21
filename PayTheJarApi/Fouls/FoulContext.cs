using MongoDB.Driver;

namespace PayTheJarApi.Fouls
{
    public class FoulContext : ContextBase
    {
        public IMongoCollection<Foul> Fouls
        {
            get
            {
                return Database.GetCollection<Foul>("Fouls");
            }
        }
    }
}