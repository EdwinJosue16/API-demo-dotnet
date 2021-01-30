using System.Collections.Generic;
using System.Web.Http;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class UsersInfoWSController : ApiController
    {
        // GET api/UsersInfoWS
        public IEnumerable<UserModel> Get()
        {
            return new DataBaseHandler().getUsersBuilder();
        }
    }
}
