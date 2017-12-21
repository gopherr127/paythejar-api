using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PayTheJarApi.Fouls
{
    public class FoulsController : ApiController
    {
        private readonly IFoulRepository _foulRepository;

        public FoulsController(IFoulRepository foulRepository)
        {
            _foulRepository = foulRepository;
        }

        public async Task<IEnumerable<Foul>> Get([FromUri]int page = 0)
        {
            return await _foulRepository.GetAll(page);
        }

        public async Task<Foul> Get(string id)
        {
            return await _foulRepository.Get(id);
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
