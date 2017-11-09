using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Common;
using System.Threading;

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
            //Thread.Sleep(4000);
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


        public ActionResult SelectedPerson(int id)
        {
            GetPerson myperson = new GetPerson();

            return View(myperson.GetPersonInfo(id));

        }

    }
}
