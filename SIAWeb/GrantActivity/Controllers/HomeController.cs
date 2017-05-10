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

            if (user != "Unknown")
            {
               ViewBag.User= user;
            }
            else
            {
                ViewBag.User= "Welcome";
            }
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }

    }
}
