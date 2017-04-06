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

        //    //string CurrentUserRole = "dd94223";
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


        

    }
}