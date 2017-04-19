using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserBusinessLayer;

namespace SOPWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            SessionUser(getUserPin());
        }

        private void SessionUser(string userPin)
        {
            HttpContext.Current.Session.Add("userName", "Unknown");
            UserLayerEntities user = new UserLayerEntities();

            var myUser = from u in user.spWebSiteUserInfo("PR93077", 2)
            //var myUser = from u in user.spWebSiteUserInfo(userPin, 2)
                         select u;
            foreach (var u in myUser)
            {
                HttpContext.Current.Session.Add("AppEntityID", u.AppEntityID.ToString());
                HttpContext.Current.Session.Add("userPin", u.PIN.ToString());
                HttpContext.Current.Session.Add("userName", u.UserName.ToString());
                HttpContext.Current.Session.Add("WebRole", u.WebRole.ToString());
            }
        }


        private string getUserPin()
        {
            string userPin = HttpContext.Current.User.Identity.Name.ToString();
            string result;
            if (userPin.Length == 12)
            {
                result = userPin.Substring(userPin.Length - 7, 7);
            }
            else
            {
                result = userPin.Substring(userPin.Length - 6, 6);
            }

            return result;
        }
    }
}