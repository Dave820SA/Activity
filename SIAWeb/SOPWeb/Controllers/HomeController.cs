using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOPWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the SOP Web App.";

            return View();
        }


        public ActionResult Search()
        {
            ViewBag.Message = "Your Search Page.";

            return View();
        }
       

        public ActionResult Contact()
        {
            ViewBag.Message = "SOP Contacts.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "SOP Admin.";

            return View();
        }
    }
}
