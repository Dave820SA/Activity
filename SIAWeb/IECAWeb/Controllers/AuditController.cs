using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IECAWeb.Models;

namespace IECAWeb.Controllers
{
    public class AuditController : Controller
    {
        private AuditEntities db = new AuditEntities();

        //
        // GET: /Audit/

        public ActionResult Index()
        {
            var audithistrories = db.AuditHistrories.Include("AppEntity");
            return View(audithistrories.ToList());
        }

        //
        // GET: /Audit/Details/5

        public ActionResult Details(int id = 0)
        {
            AuditHistrory audithistrory = db.AuditHistrories.Single(a => a.IECAID == id);
            if (audithistrory == null)
            {
                return HttpNotFound();
            }
            return View(audithistrory);
        }

        //
        // GET: /Audit/Create

        public ActionResult Create()
        {
            ViewBag.AppEntityID = new SelectList(db.AppEntities, "AppEntityID", "AppEntityID");
            return View();
        }

        //
        // POST: /Audit/Create

        [HttpPost]
        public ActionResult Create(AuditHistrory audithistrory)
        {
            if (ModelState.IsValid)
            {
                db.AuditHistrories.AddObject(audithistrory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppEntityID = new SelectList(db.AppEntities, "AppEntityID", "AppEntityID", audithistrory.AppEntityID);
            return View(audithistrory);
        }

        //
        // GET: /Audit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AuditHistrory audithistrory = db.AuditHistrories.Single(a => a.IECAID == id);
            if (audithistrory == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppEntityID = new SelectList(db.AppEntities, "AppEntityID", "AppEntityID", audithistrory.AppEntityID);
            return View(audithistrory);
        }

        //
        // POST: /Audit/Edit/5

        [HttpPost]
        public ActionResult Edit(AuditHistrory audithistrory)
        {
            if (ModelState.IsValid)
            {
                db.AuditHistrories.Attach(audithistrory);
                db.ObjectStateManager.ChangeObjectState(audithistrory, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppEntityID = new SelectList(db.AppEntities, "AppEntityID", "AppEntityID", audithistrory.AppEntityID);
            return View(audithistrory);
        }

        //
        // GET: /Audit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AuditHistrory audithistrory = db.AuditHistrories.Single(a => a.IECAID == id);
            if (audithistrory == null)
            {
                return HttpNotFound();
            }
            return View(audithistrory);
        }

        //
        // POST: /Audit/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AuditHistrory audithistrory = db.AuditHistrories.Single(a => a.IECAID == id);
            db.AuditHistrories.DeleteObject(audithistrory);
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