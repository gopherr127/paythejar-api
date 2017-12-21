using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayTheJarApi.Fouls
{
    public interface IFoulRepository
    {
        Task Add(Foul item);
        Task<Foul> Get(string id);
        Task<IEnumerable<Foul>> GetAll(int page);
        Task<bool> Remove(string id);
        Task<bool> Update(string id, Foul item);
    }
}