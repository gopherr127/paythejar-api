using System.Collections.Generic;
using System.Threading.Tasks;
using PayTheJarApi.Jars;

namespace PayTheJarApi.JarTransactions
{
    public interface IJarTransactionRepository
    {
        Task Add(Jar jar, JarTransaction item);
        Task<JarTransaction> Get(string id);
        Task<IEnumerable<JarTransaction>> Get(string jarId, int page);
        Task<bool> Remove(string id);
        Task<bool> Update(string id, JarTransaction item);
    }
}