using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWebLinksBusinessLayer;
//using SIAWeb.Models;

namespace SIAWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebLinksEntities db = new WebLinksEntities();
            List<WebLinks> siaWebLinks = db.WebLinks.ToList();
            return View(siaWebLinks);
        }

    }
}
