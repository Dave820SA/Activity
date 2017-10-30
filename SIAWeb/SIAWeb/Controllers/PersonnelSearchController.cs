using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonnelBusinessLayer;

namespace SIAWeb.Controllers
{
    public class PersonnelSearchController : Controller
    {
        PersonnelContext db = new PersonnelContext();
        //
        // GET: /PersonnelSearch/

        public ActionResult Index()
        {

            var myPeople = from l in db.People
                          orderby l.LastName
                          where l.FirstName == "David"
                          select l;

            return View(myPeople);
        }

    }
}
