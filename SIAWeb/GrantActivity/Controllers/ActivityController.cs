using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;
using System.Web.Routing;
//using GrantActivity.Common;

namespace GrantActivity.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class ActivityController : Controller
    {
        private GrantEntities db = new GrantEntities();

        //
        // GET: /Activity/

        public ActionResult Index()
        {
            var grant_activity = db.Grant_Activity.Include("Grant_Category").Include("Grant_Daily");
            return View(grant_activity.ToList());
        }

        //
        // GET: /Activity/Details/5

        public ActionResult Details(int id = 0)
        {
            Grant_Activity grant_activity = db.Grant_Activity.Single(g => g.ActivityID == id);
            if (grant_activity == null)
            {
                return HttpNotFound();
            }
            return View(grant_activity);
        }

        //
        // GET: /Activity/Create

        public ActionResult Create(int id = 0)
        {

            ViewBag.CategoryID = new SelectList(db.Grant_Category.OrderBy(x => x.Name), "CategoryID", "Name");
            ViewBag.DailyID = new SelectList(db.Grant_Daily, "AdminDailyID", "AdminNotes");
            ViewBag.DailyID = id;
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(Grant_Activity grant_activity, int id )
        {
            if (ModelState.IsValid)
            {
                db.Grant_Activity.AddObject(grant_activity);
                db.SaveChanges();
                //Notifcation mail = new Notifcation();
                //mail.NewActivity();

                //return RedirectToAction("Index");
                return RedirectToAction("Details", "Daily", new { id = id });
               
            }

            ViewBag.CategoryID = new SelectList(db.Grant_Category, "CategoryID", "Name", grant_activity.CategoryID);
            ViewBag.DailyID = id;
            //ViewBag.DailyID = new SelectList(db.Grant_Daily, "AdminDailyID", "AdminNotes", grant_activity.DailyID);
            return View(grant_activity);
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Grant_Activity grant_activity = db.Grant_Activity.Single(g => g.ActivityID == id);
            if (grant_activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Grant_Category, "CategoryID", "Name", grant_activity.CategoryID);
            ViewBag.DailyID = new SelectList(db.Grant_Daily, "AdminDailyID", "AdminNotes", grant_activity.DailyID);
            return View(grant_activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(Grant_Activity grant_activity)
        {
            if (ModelState.IsValid)
            {
                db.Grant_Activity.Attach(grant_activity);
                db.ObjectStateManager.ChangeObjectState(grant_activity, EntityState.Modified);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Details", "Daily", new { id = grant_activity.DailyID });
            }
            ViewBag.CategoryID = new SelectList(db.Grant_Category, "CategoryID", "Name", grant_activity.CategoryID);
            ViewBag.DailyID = new SelectList(db.Grant_Daily, "AdminDailyID", "AdminNotes", grant_activity.DailyID);
            return View(grant_activity);
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Grant_Activity grant_activity = db.Grant_Activity.Single(g => g.ActivityID == id);
            if (grant_activity == null)
            {
                return HttpNotFound();
            }
            return View(grant_activity);
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grant_Activity grant_activity = db.Grant_Activity.Single(g => g.ActivityID == id);
            db.Grant_Activity.DeleteObject(grant_activity);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Details", "Daily", new { id = grant_activity.DailyID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}