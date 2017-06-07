using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SIAWebLinksBusinessLayer;
using System.Text;


namespace SIAWeb.Controllers
{
    public class HomeController : Controller
    {
        WebLinksEntities db = new WebLinksEntities();

        public ActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            string user = (string)System.Web.HttpContext.Current.Session["userName"];

            if (user != "Unknown User")
            {

                sb.AppendLine("<h4>" + user + "<small>, Welcome Back! &nbsp;");
                sb.AppendLine("If you <font color='#ff6666'>experience problems</font> see the <a href='" + @Url.Action("Info", "Home") + "'>site info</a> page.</small></h4>");
               
                ViewBag.User = sb;
            }
            else
            {
                sb.AppendLine("<h5>To see content expand one of the categories and click a link.&nbsp; ");
                sb.AppendLine("If you <font color='#ff6666'>experience problems</font> see the <a href='" + @Url.Action("Info", "Home") + "'>site info</a> page.</h5>");
                ViewBag.User = sb;
            }

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

        public ActionResult Info()
        {
            return View();
        }

        //Helper method to get the ID of the web link clicked on by the user
        private int getWebAppID(string appName)
        {
            return  db.WebLinks.Where(c => c.Name == appName).Single().WebLinkID;
        }

    }
}
