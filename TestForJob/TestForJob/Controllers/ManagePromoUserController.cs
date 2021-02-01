using System.Web.Mvc;
using TestForJob.Filters;
using TestForJob.Models;

namespace TestForJob.Controllers
{
    public class ManagePromoUserController : Controller
    {
        protected PromoUsersManagementHandler promoManager = new PromoUsersManagementHandler();

        [AuthorizeUser()]
        public ActionResult ShowOptions()
        {
            return View();
        }

        [AuthorizeUser()]
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [AuthorizeUser()]
        [HttpPost]
        public ActionResult CreateUser(PromoUserModel user)
        {
            promoManager.doDataBaseOperation(promoManager.insertUser, user);
            return RedirectToAction("ShowOptions");
        }

        [AuthorizeUser()]
        [HttpGet]
        public ActionResult DeleteUser(int userId)
        {
            ActionResult resultView;
            PromoUserModel userToDelete = promoManager.findUserById(userId);
            if(userToDelete != null)
            {
                resultView = View(userToDelete);
            }
            else
            {
                resultView = RedirectToAction("ShowOptions");
            }
            return resultView;
        }

        [AuthorizeUser()]
        [HttpPost]
        public ActionResult DeleteUser(PromoUserModel user)
        {
            promoManager.doDataBaseOperation(promoManager.deleteUser, user);
            return RedirectToAction("ShowOptions");
        }

        [AuthorizeUser()]
        [HttpGet]
        public ActionResult EditUser(int userId)
        {
            ActionResult resultView;
            PromoUserModel userToEdit = promoManager.findUserById(userId);
            if(userToEdit!=null)
            {
                resultView = View(userToEdit);
            }
            else
            {
                resultView = RedirectToAction("ShowOptions");
            }
            return resultView;
        }

        [AuthorizeUser()]
        [HttpPost]
        public ActionResult EditUser(PromoUserModel user)
        {
            promoManager.doDataBaseOperation(promoManager.updateUser,user);
            return RedirectToAction("ShowOptions");
        }
    }
}