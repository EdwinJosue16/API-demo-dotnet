using System.Web.Mvc;
using TestForJob.Filters;

namespace TestForJob.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [AuthorizeUser()]
        public ActionResult Create()
        {
            return View();
        }
    }
}
