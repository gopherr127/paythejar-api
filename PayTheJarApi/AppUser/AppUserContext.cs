using MongoDB.Driver;

namespace PayTheJarApi.AppUser
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