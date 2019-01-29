using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recognition.Common;

namespace Recognition.Controllers
{
    public class AccessDeniedController : Controller
    {
        //
        // GET: /AccessDenied/

        public ActionResult Index()
        {
            PDEmployeeManager pdem = new PDEmployeeManager();
            return View(pdem.GetAppAdmins());
        }

    }
}
