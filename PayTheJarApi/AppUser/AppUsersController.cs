using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace PayTheJarApi.AppUser
{
    public class AppUsersController : ApiController
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        
        public async Task<IEnumerable<AppUser>> Get([FromUri]int page = 0)
        {
            return await _appUserRepository.GetAll(page);
        }
        
        public async Task<AppUser> Get(string id)
        {
            return await _appUserRepository.Get(id);
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
