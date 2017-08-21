using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recognition.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Recognition Contacts.";

            return View();
        }

        [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "SOP Admin.";

            return View();
        }

        public ActionResult NonUser()
        {
            return View();
        }


    }
}
