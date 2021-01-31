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
            new UsersVisualizationHandler().exportAllUsersInfoToExcel();
            return new UsersVisualizationHandler().getAllUsers();
        }
    }
}
