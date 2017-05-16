using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantReportingBusinessLayer;

namespace GrantActivity.Controllers
{
    public class DailyController : Controller
    {
        private GrantReportingEntities db = new GrantReportingEntities();

        //
        // GET: /Daily/

        public ActionResult Index()
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var dailyactivities = from d in db.DailyActivities.Where(d => d.AppEntityID == userId).OrderByDescending(date => date.EnteredDate)
                                  select d;
            return View(dailyactivities.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Answer)
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var dailyactivities = from d in db.DailyActivities.Where(d => d.AppEntityID == userId)
                                  select d;
            switch (Answer)
            {
                case "Last30":
                    var baseline = DateTime.Now.AddDays(-30);
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.EnteredDate >= baseline)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "Approve":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.ApprovedFlag == true)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "NotApprove":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.ApprovedFlag == false)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "MoreInfo":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.MoreInformationFlag == true)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "All":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId )
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                default:
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
            }

            //dailyactivities = dailyactivities.OrderByDescending(d => d.ActivityStart);
            

            //var dailyactivities = db.DailyActivities.Include("Grant_ActivityCategory");
            return View(dailyactivities.ToList());
        }


        //
        // GET: /Daily/Details/5

        public ActionResult Details(int id = 0)
        {
            DailyActivity dailyactivity = db.DailyActivities.Single(d => d.AdminActivityID == id);
            if (dailyactivity == null)
            {
                return HttpNotFound();
            }
            return View(dailyactivity);
        }

        //
        // GET: /Daily/Create

        public ActionResult Create()
        {
            ViewBag.ActivityID = new SelectList(db.ActivityCategories, "ActivityID", "Name");
            return View();
        }

        //
        // POST: /Daily/Create

        [HttpPost]
        public ActionResult Create(DailyActivity dailyactivity)
        {
            if (ModelState.IsValid)
            {


                db.DailyActivities.AddObject(dailyactivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityID = new SelectList(db.ActivityCategories, "ActivityID", "Name", dailyactivity.ActivityID);
            return View(dailyactivity);
        }

        //
        // GET: /Daily/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DailyActivity dailyactivity = db.DailyActivities.Single(d => d.AdminActivityID == id);
            if (dailyactivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityID = new SelectList(db.ActivityCategories, "ActivityID", "Name", dailyactivity.ActivityID);
            return View(dailyactivity);
        }

        //
        // POST: /Daily/Edit/5

        [HttpPost]
        public ActionResult Edit(DailyActivity dailyactivity)
        {
            if (ModelState.IsValid)
            {
                db.DailyActivities.Attach(dailyactivity);
                db.ObjectStateManager.ChangeObjectState(dailyactivity, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityID = new SelectList(db.ActivityCategories, "ActivityID", "Name", dailyactivity.ActivityID);
            return View(dailyactivity);
        }

        //
        // GET: /Daily/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DailyActivity dailyactivity = db.DailyActivities.Single(d => d.AdminActivityID == id);
            if (dailyactivity == null)
            {
                return HttpNotFound();
            }
            return View(dailyactivity);
        }

        //
        // POST: /Daily/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DailyActivity dailyactivity = db.DailyActivities.Single(d => d.AdminActivityID == id);
            db.DailyActivities.DeleteObject(dailyactivity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}