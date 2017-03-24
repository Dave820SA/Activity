using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIABusinessLayer;

namespace SIAWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebLinksBusinessLayer weblinkBusinessLayer = new WebLinksBusinessLayer();
            List<SIAWebLinks> siaWebLinks = weblinkBusinessLayer.SIAWebLinks.ToList();
            return View(siaWebLinks);
        }

    }
}
