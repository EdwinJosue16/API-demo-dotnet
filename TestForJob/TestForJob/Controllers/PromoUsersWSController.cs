using System;
using System.Web.Http;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class PromoUsersWSController : ApiController
    {
        //This method makes a user validation and send json object
        //with users promo information if the login values are from valid user
        public Object Post([FromBody]LoginValuesModel loginValues)
        {
            RequestProcessor processor = new RequestProcessor();
            if (processor.requestCanBeProcessed(loginValues))
            {
                return new PromoUsersVisualizationHandler().getAllUsers();
            }
            else
            {
                return processor.REJECTED_REQUEST;
            }
        }
    }
}
