using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOPBusinessLayer;

namespace SOPWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            SAPDActivityEntities db = new SAPDActivityEntities();
            List<SOP_vCurrentDoc> sopCurrentDoc = db.SOP_vCurrentDoc.ToList();

            ViewBag.Message = "Welcome to the SOP Web App.";

            return View(sopCurrentDoc);
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
