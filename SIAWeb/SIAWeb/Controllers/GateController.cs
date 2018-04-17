using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Models;

namespace SIAWeb.Controllers
{
    public class GateController : Controller
    {
        //
        // GET: /Gate/

        public ActionResult Index()
        {
            GateKey myQuestion = new GateKey();

            return View();
        }





    }
}
