using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrantActivity.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            string user = (string)System.Web.HttpContext.Current.Session["userName"];

            if (user != "Unknown User")
            {
                ViewBag.User = String.Format("{0}, Welcome Back!", user);
            }
            else
            {
                ViewBag.User = "You are not currently a user of this application. Contact the administrator.";
            }
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }

    }
}
