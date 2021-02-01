using TestForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private SystemUserModel user;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string operationName = ""; //It is necessary define this name
            string moduleName = ""; //It is necessary define this name
            try
            {
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