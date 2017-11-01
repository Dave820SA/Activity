using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Common;

namespace SIAWeb.Controllers
{
    public class PersonSearchController : Controller
    {
        //
        // GET: /PersonSearch/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(string search_string)
        {
            if (!String.IsNullOrEmpty(search_string))
            {
                GetPeople mySearch = new GetPeople();

                return View(mySearch.GetSearched(search_string));
            }
            else
            {
                return View();
            }

        }

    }
}
