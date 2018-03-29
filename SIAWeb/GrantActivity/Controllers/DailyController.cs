using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;
using GrantActivity.Models;
using GrantActivity.Common;

namespace GrantActivity.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class DailyController : Controller
    {
        private GrantEntities db = new GrantEntities();

        //
        // GET: /Daily/

        public ActionResult Index()
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);
            ViewBag.User = System.Web.HttpContext.Current.Session["userName"];

            var daily = activies(userId,"1");

            sortByItems();
            return View(daily.ToList());
        }

        [HttpPost]
        public ActionResult Index(string Value)
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);
            ViewBag.User = System.Web.HttpContext.Current.Session["userName"];
            var daily = activies(userId, Value);

            sortByItems();
            return View(daily.ToList());
        }

        private void  sortByItems()
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
            var dailyactivities = from d in db.Grant_Daily.Where(d => d.AppEntityID == userId)
                                  select d;

            var baseline = DateTime.Now.AddDays(-15);

            switch (selectedItem)
            {
                case "2":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.MoreInformationFlag == true
                        && d.EnteredDate >= baseline).OrderByDescending(date => date.EnteredDate);
                    break;
                case "3":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.ApprovedFlag == true
                        && d.EnteredDate >= baseline)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "4":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.ApprovedFlag == false)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                default:
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID == userId && d.EnteredDate >= baseline)
                       .OrderByDescending(date => date.EnteredDate);
                    break;
            }
            
            return dailyactivities.ToList();
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
            ViewBag.GrantTypeID = new SelectList(db.Grant_GrantType.Where(x => x.VisibleFlag == true), "GrantTypeID", "GrantType");
            ViewBag.UserID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            return View();
        }

        //
        // POST: /Daily/Create

        [HttpPost]
        public ActionResult Create(Grant_Daily grant_daily)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.GrantTypeID = new SelectList(db.Grant_GrantType, "GrantTypeID", "GrantType");
            ViewBag.UserID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];

            if (ModelState.IsValid)
            {
                db.Grant_Daily.AddObject(grant_daily);
                db.SaveChanges();
                Notifcation mail = new Notifcation();
                mail.NewActivity();
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