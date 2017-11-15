using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Common;

namespace SIAWeb.Controllers
{
    public class OfficeController : Controller
    {
        //
        // GET: /Office/

        public ActionResult Index(int id)
        {
           
            GetOffice myOffice = new GetOffice();
            return View(myOffice.GetOfficeInfo(id));
           
        }

    }
}
