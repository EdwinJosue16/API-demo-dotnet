using System;
using System.Web;
using System.Web.Mvc;
using TestForJob.Models;
using TestForJob.Controllers;

namespace TestForJob.Filters
{
    public class SessionValidation : ActionFilterAttribute
    {
        private SystemUserModel user;
        private RequestProcessor processor= new RequestProcessor();
        private const string LOGIN_VIEW = "/Access/Login";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                user = (SystemUserModel) HttpContext.Current.Session["SystemUser"];
    
                if (!processor.isValidUser(user))
                {
                    if (!(filterContext.Controller is AccessController))
                    {
                        filterContext.HttpContext.Response.Redirect(LOGIN_VIEW);
                    }
                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult(LOGIN_VIEW);
            }

        }
    }
}