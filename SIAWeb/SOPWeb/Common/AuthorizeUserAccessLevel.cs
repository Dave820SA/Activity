using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SOPWeb.Common
{
    public class AuthorizeUserAccessLevel : AuthorizeAttribute
    {
        public string UserRole { get; set; }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string CurrentUserRole = (string)System.Web.HttpContext.Current.Session["WebRole"];
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

            if (!this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
                // The user is not in any of the listed roles => 
                // show the unauthorized view
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "action", "Index" },
                        { "controller", "AccessDenied" }

                    });
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }

    }
}