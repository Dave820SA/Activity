using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIABusinessLayer;
using SIAUserBusinessLayer;
using SIAWeb.Models;

namespace SIAWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SIAUserEntities user = new SIAUserEntities();
            List<CurrentUser> currentUser = new List<CurrentUser>();
           
            var myUser = from u in user.spGetSIAWebUserInfo("dd94223")
                       select u;
            
                foreach (var u in myUser)
                {
                    CurrentUser theUser = new CurrentUser();
                    theUser.AppEntityID = Convert.ToInt32(u.AppEntityID);
                    theUser.PIN = u.PIN.ToString();
                    theUser.SAP = u.SAP.ToString();

                    theUser.UserName = u.UserName.ToString();
                    theUser.DutyStatus = u.DutyStatus.ToString();
                    theUser.OfficeCode = u.OfficeCode.ToString();

                    currentUser.Add(theUser);
                }
                ViewData["TheUser"] = currentUser;
          
           

            WebLinksBusinessLayer weblinkBusinessLayer = new WebLinksBusinessLayer();
            List<SIAWebLinks> siaWebLinks = weblinkBusinessLayer.SIAWebLinks.ToList();
            return View(siaWebLinks);
        }

    }
}
