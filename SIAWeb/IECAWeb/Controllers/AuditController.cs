﻿using System;
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

        
        public ActionResult Index(int id)
        {
            //int officeID = int.Parse(Request.QueryString["id"]);
            //string office = Request.QueryString();
            //var audithistrories = db.AuditHistrories.Include("AppEntity");
            var audithistrories = auditHistory(id, DateTime.Now);
            return View(audithistrories.ToList());
        }

        private IList<AuditHistrory> auditHistory(int office, DateTime myDate)
        {
            int mo = partOfDate("Month", myDate);
            int yr = partOfDate("Year", myDate);
            //string newDate = myDate.ToShortDateString();

            var history = from d in db.AuditHistrories
                          where d.AuditDate.Value.Year == yr && d.AuditDate.Value.Month == mo
                          select d;

            return history.ToList();
        }

        private int partOfDate(string direct, DateTime mydate)
        {
            int getDatePart;
            if (direct == "Month")
            {
                getDatePart = mydate.Month;
            }
            else
            {
                getDatePart = mydate.Year;
            }

            return getDatePart;   

        }

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