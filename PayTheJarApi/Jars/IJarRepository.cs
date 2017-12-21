using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.Jars
{
    public interface IJarRepository
    {
        Task<IEnumerable<Jar>> GetAll(int page);
        Task<Jar> Get(string id);

        Task Add(Jar item);
        Task<bool> Remove(string id);
        Task<bool> Update(string id, Jar item);
    }
}