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
            DataBaseHandler dataHandler = new DataBaseHandler();
            return dataHandler.getAllUsers();
        }

    }
}
