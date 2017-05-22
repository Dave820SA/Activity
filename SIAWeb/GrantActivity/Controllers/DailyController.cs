using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;
using GrantActivity.Models;

namespace GrantActivity.Controllers
{
    public class DailyController : Controller
    {
        private GrantEntities db = new GrantEntities();

        //
        // GET: /Daily/

        public ActionResult Index()
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var daily = from d in db.Grant_Daily
                        select d;

            daily = daily.Where(d => d.AppEntityID == userId && d.ApprovedFlag == false);

            return View(daily.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Answer)
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var dailyactivities = from d in db.Grant_Daily.Where(d => d.AppEntityID == userId)
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
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                default:
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
            }

            return View(dailyactivities.ToList());
        }

        //
        // GET: /Daily/Details/5

        public ActionResult Details(int id = 0)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            if (grant_daily == null)
            {
                return HttpNotFound();
            }


            var activity = from a in db.Grant_Activity
                        select a;

            activity = activity.Where(a => a.DailyID == id);

            ViewData["Activities"] = activity;

            return View(grant_daily);
        }

       

        //
        // GET: /Daily/Create

        public ActionResult Create()
        {
            ViewBag.GrantTypeID = new SelectList(db.Grant_GrantType, "GrantTypeID", "GrantType");
            ViewBag.UserID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            return View();
        }

        //
        // POST: /Daily/Create

        [HttpPost]
        public ActionResult Create(Grant_Daily grant_daily)
        {
            if (ModelState.IsValid)
            {
                db.Grant_Daily.AddObject(grant_daily);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = grant_daily.AdminDailyID });
            }

            ViewBag.GrantTypeID = new SelectList(db.Grant_GrantType, "GrantTypeID", "GrantType", grant_daily.GrantTypeID);
            return View(grant_daily);
        }

        //
        // GET: /Daily/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            if (grant_daily == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrantTypeID = new SelectList(db.Grant_GrantType, "GrantTypeID", "GrantType", grant_daily.GrantTypeID);
            return View(grant_daily);
        }

        //
        // POST: /Daily/Edit/5

        [HttpPost]
        public ActionResult Edit(Grant_Daily grant_daily)
        {
            if (ModelState.IsValid)
            {
                db.Grant_Daily.Attach(grant_daily);
                db.ObjectStateManager.ChangeObjectState(grant_daily, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrantTypeID = new SelectList(db.Grant_GrantType, "GrantTypeID", "GrantType", grant_daily.GrantTypeID);
            return View(grant_daily);
        }

        //
        // GET: /Daily/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            if (grant_daily == null)
            {
                return HttpNotFound();
            }
            return View(grant_daily);
        }

        //
        // POST: /Daily/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            db.Grant_Daily.DeleteObject(grant_daily);
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