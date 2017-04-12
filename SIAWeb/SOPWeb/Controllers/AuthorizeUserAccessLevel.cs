using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public class AuthorizeUserAccessLevel : AuthorizeAttribute
    {
        public string UserRole { get; set; }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            string CurrentUserRole = (string)System.Web.HttpContext.Current.Session["WebRole"];
            //if (this.UserRole.Contains(CurrentUserRole))
            if (this.UserRole.Contains(CurrentUserRole))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // The user is not authenticated
                base.HandleUnauthorizedRequest(filterContext);
            }
            else if (!this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                // The user is not in any of the listed roles => 
                // show the unauthorized view
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/NonUser/Index.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}