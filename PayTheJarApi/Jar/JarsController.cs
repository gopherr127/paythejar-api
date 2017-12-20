using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PayTheJarApi.Jar
{
    public class JarsController : ApiController
    {
        private readonly IJarRepository _jarRepository;

        public JarsController(IJarRepository jarRepository)
        {
            _jarRepository = jarRepository;
        }
        
        public async Task<IEnumerable<Jar>> Get([FromUri]int page = 0)
        {
            return await _jarRepository.GetAll(page);
        }
        
        public async Task<Jar> Get(string id)
        {
            return await _jarRepository.Get(id);
        }
        
        public void Post([FromBody]string value)
        {

        }
        
        public void Put(int id, [FromBody]string value)
        {
        }
        
        public void Delete(int id)
        {
        }
    }
}
