using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SOPBusinessLayer;
using PagedList;
using System.Text;
using SOPWeb.Common;

namespace SOPWeb.Controllers
{
    public class HomeController : Controller
    {
        SAPDActivityEntities db = new SAPDActivityEntities();

        [OutputCache(Duration=10)]
        public ActionResult Index()
        {
            StringBuilder sb = new StringBuilder();
            string user = (string)System.Web.HttpContext.Current.Session["userName"];

            if (user != "Unknown User")
            {
                sb.AppendLine("<h4>" + user + "<small>, Welcome Back! &nbsp; </small></h4>");
               
                ViewBag.User = sb;
            }
            else
            {
                sb.AppendLine("<h5>To see content expand one of the categories and click a link.&nbsp;</h5> ");
               
                ViewBag.User = sb;
            }

            SOPManager sm = new SOPManager();
            var model = sm.GetCurrentSOP().ToList();
            return View(model);
        }

       
        //track the clicked links
        public ActionResult updateStats(string link, string page)
        {
            ActivityLog track = new ActivityLog();
            track.WebAppID = 13;
            string appID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            if (appID != null)
            {
                track.AppEntityID = Int32.Parse(appID);
            }
            track.Link = link;
            track.WebPage = page;
            track.ClickedDatetime = DateTime.Parse(DateTime.Now.ToString());
            track.Flagged = false;

            db.ActivityLogs.AddObject(track);
            db.SaveChanges();

            return View();
        }


        public ActionResult Info()
        {
            return View();
        }

        [OutputCache(Duration = 10)]
        public ViewResult Search(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == "sop_aesc" || sortOrder == "")
            {
                ViewBag.NameSortParm = "sop_desc";
            }
            else
            {
                ViewBag.NameSortParm = "sop_aesc";
            }
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "sop_desc" : "sop_aesc";
            ViewBag.DateSortParm = sortOrder == "LastUpdate" ? "date_desc" : "LastUpdate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var sop = from s in db.DocHistories.Where(s => s.EndDate == null)
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sop = sop.Where(s => s.SOP_SOP.Name.Contains(searchString)
                                       || s.DocInfo.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "sop_desc":
                    sop = sop.OrderByDescending(s => s.SOP_SOP.Name);
                    break;
                case "sop_aesc":
                    sop = sop.OrderBy(s => s.SOP_SOP.Name);
                    break;
                case "StartDate":
                    sop = sop.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    sop = sop.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    sop = sop.OrderBy(s => s.StartDate);
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sop.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int id = 0)
        {
            DocHistory dochistory = db.DocHistories.Single(d => d.DocHistoryID == id);
            if (dochistory == null)
            {
                return HttpNotFound();
            }
            return View(dochistory);
        }


        public ActionResult Contact()
        {
            ViewBag.GroupName = "SOP Administrators";
            ViewBag.GroupInfo = "Point of contact for SOP issues.";
            PersonManager pm = new PersonManager();
            var model = pm.GetAdminMember();
            return View(model);
        }

        [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "SOP Admin.";

            return View();
        }
    }
}
