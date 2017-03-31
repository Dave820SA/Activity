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

            //var myUser = from u in user.spGetSIAWebUserInfo("db94223")
            var myUser = from u in user.spGetSIAWebUserInfo(getUserPin())
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

        private string getUserPin()
        {
            //string clientAddress = Request.UserHostAddress.ToString();
            string userPin = Request.LogonUserIdentity.Name.ToString();
            string result;
            if (userPin.Length == 12)
            {
               result = userPin.Substring(userPin.Length-7, 7);
            }
            else
            {
                result = userPin.Substring(userPin.Length-6, 6);
            }

            return result;
        }
    }
}
