using System;
using System.Web.Http;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class PromoUsersWSController : ApiController
    {
        public Object Get()
        {
            var user = new PromoUserModel {
                firstName = "TEST3",
                lastName = "TEST3",
                cellPhoneNumber = "TEST3",
                typeOfPromo = "TEST3",
                entryDate = DateTime.Now
            };
            var x = new PromoUsersManagementHandler();
            x.doDataBaseOperation(x.insertUser,user);
            return new PromoUsersVisualizationHandler().getAllUsers();
        }

        //This method makes a user validation and send json object
        //with users promo information if the login values are from valid user
        public Object Post([FromBody]LoginValuesModel loginValues)
        {
            RequestProcessor processor = new RequestProcessor();
            if (processor.isPossibleReturnPromoUsersInfo(loginValues))
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
