using TestForJob.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace TestForJob.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private SystemUserModel user;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string operationName = "Operation name"; //It is for example
            string moduleName = "Module name"; //It is for example
            try
            {
                //Obtain session user
                user = (SystemUserModel) HttpContext.Current.Session["SystemUser"];
                if (!user.canModifyPromoUsers())
                {
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operation=" + 
                        operationName +
                        "&modulo=" + 
                        moduleName
                    );
                }
            }
            catch (Exception error)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operation=" + 
                    operationName + 
                    "&module=" + 
                    moduleName + 
                    "&msgErrorExcepcion=" + 
                    error.Message
                );
            }
        }               

    }
}