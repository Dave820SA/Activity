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

        //Not used
        public ActionResult SelectedPerson(int id)
        {
            GetPerson myperson = new GetPerson();

            return View(myperson.GetPersonInfo(id));

        }

        public ActionResult SelectPerson(int id)
        {
            //Load all work history information into ViewData object to use on partial page
            PersonWorkProfileGet myWorkProfile = new PersonWorkProfileGet();
            ViewData["WorkProfile"] = myWorkProfile.GetPersonInfo(id);

            //Load basic serached for Person info and return it to the view for 
            //use in the PersonBasic partial view
            PersonBasicGet myPersonBasic = new PersonBasicGet();
            return View(myPersonBasic.GetPersonBasicInfo(id));
        }


        public ActionResult GetPersonBasic(int id)
        {
            PersonBasicGet myPersonBasic = new PersonBasicGet();

            return PartialView("_PersonBasic", myPersonBasic.GetPersonBasicInfo(id));
        }


    }
}
