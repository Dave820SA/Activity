using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIAWeb.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            if ((string)System.Web.HttpContext.Current.Session["WebRole"] == "SuperUser")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Contact");
            }

            
            
        }

    }
}
