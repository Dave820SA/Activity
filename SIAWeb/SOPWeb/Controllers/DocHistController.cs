﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOPBusinessLayer;

namespace SOPWeb.Controllers
{
    public class DocHistController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
        // GET: /DocHist/

        public ActionResult Index()
        {
            var dochistories = db.DocHistories.Include("SOP_SOP");
            return View(dochistories.ToList());
        }

        //
        // GET: /DocHist/Details/5

        public ActionResult Details(int id = 0)
        {
            DocHistory dochistory = db.DocHistories.Single(d => d.DocHistoryID == id);
            if (dochistory == null)
            {
                return HttpNotFound();
            }
            return View(dochistory);
        }

        //
        // GET: /DocHist/Create

        public ActionResult Create()
        {
            ViewBag.SOPID = new SelectList(db.SOPs, "SOPID", "Name");
            return View();
        }

        //
        // POST: /DocHist/Create

        [HttpPost]
        public ActionResult Create(DocHistory dochistory)
        {
            if (ModelState.IsValid)
            {
                db.DocHistories.AddObject(dochistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SOPID = new SelectList(db.SOPs, "SOPID", "Name", dochistory.SOPID);
            return View(dochistory);
        }

        //
        // GET: /DocHist/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DocHistory dochistory = db.DocHistories.Single(d => d.DocHistoryID == id);
            if (dochistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SOPID = new SelectList(db.SOPs, "SOPID", "Name", dochistory.SOPID);
            return View(dochistory);
        }

        //
        // POST: /DocHist/Edit/5

        [HttpPost]
        public ActionResult Edit(DocHistory dochistory)
        {
            if (ModelState.IsValid)
            {
                db.DocHistories.Attach(dochistory);
                db.ObjectStateManager.ChangeObjectState(dochistory, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SOPID = new SelectList(db.SOPs, "SOPID", "Name", dochistory.SOPID);
            return View(dochistory);
        }

        //
        // GET: /DocHist/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DocHistory dochistory = db.DocHistories.Single(d => d.DocHistoryID == id);
            if (dochistory == null)
            {
                return HttpNotFound();
            }
            return View(dochistory);
        }

        //
        // POST: /DocHist/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DocHistory dochistory = db.DocHistories.Single(d => d.DocHistoryID == id);
            db.DocHistories.DeleteObject(dochistory);
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