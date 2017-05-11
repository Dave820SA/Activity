using System;
using System.Data;
using System.IO;
//using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using GrantReportingBusinessLayer;

namespace GrantActivity.Controllers
{
    public class CategoryController : Controller
    {
        private GrantReportingEntities db = new GrantReportingEntities();

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(db.ActivityCategories.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            ActivityCategory activitycategory = db.ActivityCategories.Single(a => a.ActivityID == id);
            if (activitycategory == null)
            {
                return HttpNotFound();
            }
            return View(activitycategory);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(ActivityCategory activitycategory)
        {
            if (ModelState.IsValid)
            {
                db.ActivityCategories.AddObject(activitycategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activitycategory);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ActivityCategory activitycategory = db.ActivityCategories.Single(a => a.ActivityID == id);
            if (activitycategory == null)
            {
                return HttpNotFound();
            }
            return View(activitycategory);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(ActivityCategory activitycategory)
        {
            if (ModelState.IsValid)
            {
                db.ActivityCategories.Attach(activitycategory);
                db.ObjectStateManager.ChangeObjectState(activitycategory, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activitycategory);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ActivityCategory activitycategory = db.ActivityCategories.Single(a => a.ActivityID == id);
            if (activitycategory == null)
            {
                return HttpNotFound();
            }
            return View(activitycategory);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityCategory activitycategory = db.ActivityCategories.Single(a => a.ActivityID == id);
            db.ActivityCategories.DeleteObject(activitycategory);
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