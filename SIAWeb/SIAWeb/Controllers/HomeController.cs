using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SIAWebLinksBusinessLayer;
using System.Text;
using System.Web.UI.WebControls;
using SIAWeb.Models;


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
                if (browserIssue())
                {
                    sb.AppendLine("If you <font color='#ff6666'>experience problems</font> see the <a href='" + @Url.Action("Info", "Home") + "'>site info</a> page.</small></h4>");
                }
                else
                {
                    sb.AppendLine("</small></h4>");
                }
                
                ViewBag.User = sb;
            }
            else
            {
                sb.AppendLine("<h5>To see content expand one of the categories and click a link.&nbsp; ");
                if (browserIssue())
                {
                    sb.AppendLine("If you <font color='#ff6666'>experience problems</font> see the <a href='" + @Url.Action("Info", "Home") + "'>site info</a> page.</h5>");
                }
                else
                {
                    sb.AppendLine("</h5>");
                }
                ViewBag.User = sb;
            }

            List<webLink> web_Link = new List<webLink>();
            List<topLink> top_Link = new List<topLink>();

            var myLinks = from l in db.WebLinks
                          orderby l.Name
                          where l.VisibleFlag == true
                          select l;

            foreach (var L in myLinks)
            {
                web_Link.Add(new webLink { category = L.WebCategoryID, link = L.Name, linkPath = L.WebLink });
            }

            var myTopLinks = from T in db.Activity_spMyTopWebLinks((string)System.Web.HttpContext.Current.Session["userPin"])
                             select T;

            foreach (var T in myTopLinks)
            {
                top_Link.Add(new topLink { toplink = T.TopLink.Trim(), toplinkpath = T.TopLinkPath.Trim() });
            }

            WebLinkModel finalItem = new WebLinkModel();
            finalItem.WebLinks = web_Link;
            finalItem.TopLinks = top_Link;

            return View(finalItem);



            //TopLinkManager link = new TopLinkManager();
            //List<topLink> myLinks = link.GetTopLinks((string)System.Web.HttpContext.Current.Session["userPin"]);
            //ViewData["myLinks"] = link.GetTopLinks((string)System.Web.HttpContext.Current.Session["userPin"]);

            //List<WebLinks> siaWebLinks = db.WebLinks.Where(s => s.VisibleFlag).ToList();
            //return View(siaWebLinks);
        }


        private Boolean browserIssue()
        {
            string browser = Request.Browser.Browser;
            if (browser == "Chrome")
            {
                return true;
            }
            else
            {
                return false;
            }
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

            string appLink;
            string s2 = "\n";
            bool b = link.Contains(s2);
            if (b)
            {
                appLink = link.Substring(0, link.Length - 21);
            }
            else
            {
                appLink = link;
            };

            track.Link = appLink;
            track.WebPage = page;
            track.WebLinkID = getWebAppID(appLink);
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
            return db.WebLinks.Where(c => c.Name == appName).Single().WebLinkID;
        }

    }
}
