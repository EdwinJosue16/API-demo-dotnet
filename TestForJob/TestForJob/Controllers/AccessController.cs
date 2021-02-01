using TestForJob.Models;
using System.Web.Mvc;
using System;

namespace TestForJob.Controllers
{
    public class AccessController : Controller
    {
        protected RequestProcessor processor = new RequestProcessor();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginValuesModel loginValues)
        {
            ActionResult loginViewResult = View();
            try
            {
                SystemUserModel user = processor.getUserFromDB(loginValues);
                if (processor.isValidUser(user))
                {
                    Session["SystemUser"] = user;
                    loginViewResult = RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password";
                }
            }
            catch (Exception error)
            {
                ViewBag.ErrorMessage = error.Message;
            }
            return loginViewResult;
        }
    }
}