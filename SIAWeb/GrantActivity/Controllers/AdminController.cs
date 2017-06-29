using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;
using GrantActivity.Models;
using System.Data;

namespace GrantActivity.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class AdminController : Controller
        
    {
        private GrantEntities db = new GrantEntities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var daily = activies(userId, "1");
            sortByItems();
            return View(daily.ToList());

        }

        [HttpPost]
        public ActionResult Index(string Value)
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);
            var daily = activies(userId, Value);

            sortByItems();
            return View(daily.ToList());
        }

        private void sortByItems()
        {
            List<SelectListItem> sortBy = new List<SelectListItem>();
            sortBy.Add(new SelectListItem { Text = "All", Value = "1" });
            sortBy.Add(new SelectListItem { Text = "More Info", Value = "2" });
            sortBy.Add(new SelectListItem { Text = "Approved", Value = "3" });
            sortBy.Add(new SelectListItem { Text = "Not Approved", Value = "4" });
            ViewBag.SortBy = new SelectList(sortBy, "Value", "Text", "1");
        }

        private IList<GrantBusinessLayer.Grant_Daily> activies(int userId, string selectedItem)
        {
            var dailyactivities = from d in db.Grant_Daily
                                  select d;

            var baseline = DateTime.Now.AddDays(-30);

            switch (selectedItem)
            {
                case "2":
                       dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.MoreInformationFlag == true
                           && d.EnteredDate >= baseline)
                       .OrderByDescending(date => date.EnteredDate);
                   break;
                case "3":
                   dailyactivities = dailyactivities.Where(d => d.ApprovedFlag == true && d.EnteredDate >= baseline)
                           .OrderByDescending(date => date.EnteredDate);
                      break;
                case "4":
                       dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.ApprovedFlag == false
                           && d.EnteredDate >= baseline)
                          .OrderByDescending(date => date.EnteredDate);
                      break;
                default:
                      dailyactivities = dailyactivities.Where(d =>  d.EnteredDate >= baseline != (d.AppEntityID == userId && d.ApprovedFlag == false) )
                           .OrderByDescending(date => date.EnteredDate);
                       break;
            }

            return dailyactivities.ToList();
        }



        public ActionResult Search()
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            DateTime startDate;
            DateTime endDate;
            //if (fromDate.HasValue)
            //{
            //    endDate = fromDate.Value;
            //    endDate = endDate.Add(TimeSpan.Parse("00:00:01"));
            //}
            //else
            //{
            endDate = DateTime.Now.AddDays(-60);
            //}

            //if (toDate.HasValue)
            //{
            //    startDate = toDate.Value;
            //    startDate = startDate.Add(TimeSpan.Parse("11:59:59"));
            //}
            //else
            //{
                startDate = DateTime.Now.AddDays(-30);
            //}
            
            //DateTime endDate = DateTime.Now.AddDays(-60);
            var daily = searchActivies(userId, endDate, startDate);

            return View(daily.ToList());

        }


        [HttpPost, ActionName("Search")]
        public ActionResult Search(DateTime? fromDate, DateTime? toDate)
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);
            //DateTime fDate = fromDate.Add(TimeSpan.Parse("00:00:01"));
            //DateTime tDate = toDate.Add(TimeSpan.Parse("11:59:59"));
            //var daily = searchActivies(userId, fDate, tDate);
            var daily = searchActivies(userId, fromDate, toDate);


            return View(daily.ToList());
        }

        //[HttpGet]
        //public JsonResult DoGet(DateTime fromDate, DateTime toDate)
        //{
        //    int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

        //    var daily = searchActivies(userId, fromDate, toDate);

        //    //return View(daily.ToList());

        //    return View(daily.ToList(), JsonRequestBehavior.AllowGet);
        //}


        private IList<GrantBusinessLayer.Grant_Daily> searchActivies(int? userId, DateTime? fromDate, DateTime? toDate)
        {
            
            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            var dailyactivities = from d in db.Grant_Daily
                                  where d.DailyEnd >= fromDate && d.DailyStart <= toDate
                                  select d;
            return dailyactivities.ToList();
        }

        //
        // GET: /Daily/Details/5
        //[HttpGet]
        public ActionResult Details(int id = 0)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            if (grant_daily == null )
            {
                //return HttpNotFound();
                return Redirect("Index");
            }

            var activity = from a in db.Grant_Activity
                           select a;

            activity = activity.Where(a => a.DailyID == id);

            ViewData["Activities"] = activity;

            return View(grant_daily);
        }


        //Approve items
        public void approve(int id)
        {
            var approv = db.Grant_Daily.FirstOrDefault(x => x.AdminDailyID == id);

            approv.ApprovedFlag = true;
            approv.MoreInformationFlag = false;
            string user = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            approv.ApprovedByID = int.Parse(user);
            approv.ApprovedDate = DateTime.Now;

            db.SaveChanges();

            RedirectToAction("Index", "Admin");
        }

        //Ask the user for more information
        public void moreInfo(string info, int id)
        {
            var approv = db.Grant_Daily.FirstOrDefault(x => x.AdminDailyID == id);
            approv.MoreInformationFlag = true;
            approv.AdminNotes = info;
            db.SaveChanges();

        }


        

    }
}
