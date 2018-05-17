using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Common;
using System.Threading;
using SIAWebLinksBusinessLayer;

namespace SIAWeb.Controllers
{
    public class PersonSearchController : Controller
    {
        WebLinksEntities db = new WebLinksEntities();

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
            int searchId;
            if (id != 0)
            {
                searchId = id;
                updateSearchFor(searchId);
            }
            else
            {
                searchId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);
            }
            //Update the searched for table
            

            //Load all work history information into ViewData object to use on partial page
            PersonWorkProfileGet myWorkProfile = new PersonWorkProfileGet();
            ViewData["WorkProfile"] = myWorkProfile.GetPersonInfo(searchId);

            //Load basic serached for Person info and return it to the view for 
            //use in the PersonBasic partial view
            PersonBasicGet myPersonBasic = new PersonBasicGet();
            return View(myPersonBasic.GetPersonBasicInfo(searchId));
        }


        public ActionResult GetPersonBasic(int id)
        {
            PersonBasicGet myPersonBasic = new PersonBasicGet();

            return PartialView("_PersonBasic", myPersonBasic.GetPersonBasicInfo(id));
        }


        public string activeButton(string direct)
        {
            switch (direct)
            {
                case "Home":
                    return "liPersonnalProfile";
                case "Personnal":
                    return "liWebsiteAccess";
                default:
                    return "liWorkProfile";
            }
        }

        private void updateSearchFor(int searchFor)
        {
            //Update the serachedFor table if the user selects a user from the table
            //that is not him/herself
            SearchFor track = new SearchFor();
            string appID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            
            if (appID != null && Int32.Parse(appID) >= 3)
            {
                if (Int32.Parse(appID) != searchFor)
                {
                    track.AppEntityID = Int32.Parse(appID);
                    track.SearchForID = searchFor;
                    track.SearchDateTime = DateTime.Parse(DateTime.Now.ToString());

                    db.SearchFors.AddObject(track);
                    db.SaveChanges();
                }
            }

        }
    }
}
