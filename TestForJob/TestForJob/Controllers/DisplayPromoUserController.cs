using System;
using System.Web.Mvc;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class DisplayPromoUserController : Controller
    {
        protected const int PHONE_FILTER = 0;
        protected const int PROMO_FILTER = 1;
        protected const int DATE_FILTER = 2;

        protected PromoUsersVisualizationHandler promoDisplay = new PromoUsersVisualizationHandler();
        
        public ActionResult ShowOptions()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ExportUsersInfo()
        {
            promoDisplay.exportAllUsersInfoToExcel();
            return RedirectToAction("ShowOptions");
        }

        [HttpGet]
        public ActionResult SeeAllUsers()
        {
            return View(promoDisplay.getAllUsers());
        }

 
        public ActionResult SeeUsersByFilter()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SeeUsersByFilter(int filter, string valueFilter)
        {
            ActionResult viewResult;

            switch(filter)
            {
                case PROMO_FILTER:
                    viewResult = View(promoDisplay.getUserByPromo(valueFilter));
                    break;

                case PHONE_FILTER:
                    viewResult = View(promoDisplay.getUserByPhoneNumber(valueFilter));
                    break;
                case DATE_FILTER:
                    viewResult = RedirectToAction("SelectDatesFilter");
                    break;
                default:
                    viewResult = RedirectToAction("SeeUsersByFilter");
                    break;
            }
            return viewResult;
        }

        public ActionResult SelectDatesFilter()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SeeUserByDates(DateTime minDate, DateTime maxDate)
        {
            return View(promoDisplay.getUsersBetweenDates(minDate,maxDate));
        }


    }
}