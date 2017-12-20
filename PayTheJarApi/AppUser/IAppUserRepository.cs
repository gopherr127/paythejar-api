using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.AppUser
{
    public interface IAppUserRepository
    {
        Task Add(AppUser item);
        Task<AppUser> Get(string id);
        Task<IEnumerable<AppUser>> GetAll(int page);
        Task<bool> Remove(string id);
        Task<bool> Update(string id, AppUser item);
    }
}