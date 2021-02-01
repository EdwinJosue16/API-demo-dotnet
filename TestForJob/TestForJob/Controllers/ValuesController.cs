using System;
using System.Collections.Generic;
using System.Web.Http;
namespace TestForJob.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        //It is for testing
        // GET api/values/5
        public Object Get(int id)
        {
            const int PHONE_FILTER = 0;
            const int PROMO_FILTER = 1;
            var promoDisplay = new PromoUsersVisualizationHandler();
            Object viewResult;

            switch (id)
            {
                case PROMO_FILTER:
                    viewResult = promoDisplay.getUserByPromo("type-2");
                    break;

                case PHONE_FILTER:
                    viewResult = promoDisplay.getUserByPhoneNumber("12345678");
                    break;
                default:
                    viewResult = promoDisplay.getAllUsers();
                    break;
            }
            return viewResult;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
