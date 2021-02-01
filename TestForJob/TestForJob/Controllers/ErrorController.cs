using System.Web.Mvc;

namespace TestForJob.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult UnauthorizedOperation(string operation, string module, string msgErrorExcepcion)
        {
            ViewBag.operation = operation;
            ViewBag.module = module;
            ViewBag.msgErrorExcepcion = msgErrorExcepcion;
            return View();
        }
    }
}