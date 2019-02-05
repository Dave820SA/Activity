using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recognition.Common;
using RecognitionBusinessLayer;

namespace Recognition.Controllers
{
    public class AwardTypeController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

   
        [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Index()
        {
            return View(db.AwardTypes.ToList());
        }

        //
        // GET: /AwardType/Details/5

        public ActionResult Details(int id = 0)
        {
            AwardType awardtype = db.AwardTypes.Single(a => a.AwardTypeId == id);
            if (awardtype == null)
            {
                return HttpNotFound();
            }
            return View(awardtype);
        }

        //
        // GET: /AwardType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AwardType/Create

        [HttpPost]
        public ActionResult Create(AwardType awardtype)
        {
            if (ModelState.IsValid)
            {
                db.AwardTypes.AddObject(awardtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(awardtype);
        }

        //
        // GET: /AwardType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AwardType awardtype = db.AwardTypes.Single(a => a.AwardTypeId == id);
            if (awardtype == null)
            {
                return HttpNotFound();
            }
            return View(awardtype);
        }

        //
        // POST: /AwardType/Edit/5

        [HttpPost]
        public ActionResult Edit(AwardType awardtype)
        {
            if (ModelState.IsValid)
            {
                db.AwardTypes.Attach(awardtype);
                db.ObjectStateManager.ChangeObjectState(awardtype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(awardtype);
        }

        //
        // GET: /AwardType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AwardType awardtype = db.AwardTypes.Single(a => a.AwardTypeId == id);
            if (awardtype == null)
            {
                return HttpNotFound();
            }
            return View(awardtype);
        }

        //
        // POST: /AwardType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AwardType awardtype = db.AwardTypes.Single(a => a.AwardTypeId == id);
            db.AwardTypes.DeleteObject(awardtype);
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