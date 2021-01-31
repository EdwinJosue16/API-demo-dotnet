using System.Collections.Generic;
using System.Web.Http;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class PromoUsersWSController : ApiController
    {
        // GET api/UsersInfoWS
        public IEnumerable<PromoUserModel> Get()
        {
            return new PromoUsersVisualizationHandler().getAllUsers();
        }

        public IEnumerable<PromoUserModel> Post([FromBody]PromoUserModel user)
        {
            return new PromoUsersVisualizationHandler().getAllUsers();
        }
    }
}
