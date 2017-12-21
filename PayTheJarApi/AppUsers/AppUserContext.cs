using MongoDB.Driver;

namespace PayTheJarApi.AppUsers
{
    public class AppUserContext : ContextBase
    {
        public IMongoCollection<AppUser> AppUsers
        {
            get
            {
                return Database.GetCollection<AppUser>("AppUsers");
            }
        }
    }
}