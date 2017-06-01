using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SIAWebLinksBusinessLayer;


namespace SIAWeb.Controllers
{
    public class HomeController : Controller
    {
        WebLinksEntities db = new WebLinksEntities();

        public ActionResult Index()
        {
            //List<WebLinks> siaWebLinks = db.WebLinks.ToList();
            List<WebLinks> siaWebLinks = db.WebLinks.Where(s => s.VisibleFlag).ToList();
            return View(siaWebLinks);
        }

        //track the clicked links, called from Ajax on the Index view
        public void updateStats(string link, string page)
        {
            ActivityLog track = new ActivityLog();
            track.WebAppID = 23;
            string appID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            if (appID != null)
            {
                track.AppEntityID = Int32.Parse(appID);
            }
            track.Link = link;
            track.WebPage = page;
            track.WebLinkID = getWebAppID(link);
            track.ClickedDatetime = DateTime.Parse(DateTime.Now.ToString());
            track.Flagged = false;

            db.ActivityLogs.AddObject(track);
            db.SaveChanges();

        }

        //Helper method to get the ID of the web link clicked on by the user
        private int getWebAppID(string appName)
        {
            return  db.WebLinks.Where(c => c.Name == appName).Single().WebLinkID;
        }

    }
}
