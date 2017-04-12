using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIAWeb.Controllers
{
    public class AdminController : Controller
    {


        [AuthorizeUserAccessLevel(UserRole = "SuperUser")]
        public ActionResult Index()
        {

            return View();

        }

    }
}
