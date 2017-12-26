using PayTheJarApi.JarTransactions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PayTheJarApi.Jars
{
    [RoutePrefix("api/jars")]
    public class JarsController : ApiController
    {
        private readonly IJarRepository _jarRepository;
        private readonly IJarTransactionRepository _jarTransactionRepository;

        public JarsController(
            IJarRepository jarRepository,
            IJarTransactionRepository jarTransactionRepository)
        {
            _jarRepository = jarRepository;
            _jarTransactionRepository = jarTransactionRepository;
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Jar>> Get([FromUri]int page = 0)
        {
            return await _jarRepository.GetAll(page);
        }
        
        [Route("{id}")]
        [HttpGet]
        public async Task<Jar> Get(string id)
        {
            return await _jarRepository.Get(id);
        }

        [Route("")]
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        [Route("{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
        }

        [Route("{id}/transactions")]
        [HttpGet]
        public async Task<IEnumerable<JarTransaction>> GetTransactions(string id, [FromUri]int page = 0)
        {
            return await _jarTransactionRepository.Get(id, page);
        }
    }
}
