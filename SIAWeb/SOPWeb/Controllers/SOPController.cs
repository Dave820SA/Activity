using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOPBusinessLayer;
using System.IO;

namespace SOPWeb.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class SOPController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
        // GET: /SOP/

        public ActionResult Index()
        {
            var sops = db.SOPs.Include("Office_Bureau");
            return View(sops.ToList());
        }

        //
        // GET: /SOP/Details/5

        public ActionResult Details(int id = 0)
        {
            SOP sop = db.SOPs.Single(s => s.SOPID == id);
            if (sop == null)
            {
                return HttpNotFound();
            }
            return View(sop);
        }

       


        //
        // GET: /SOP/Create

        public ActionResult Create()
        {
            ViewBag.BureauID = new SelectList(db.Bureaux, "BureauID", "Name");
            return View();
        }

        
         //POST: /SOP/Create

        [HttpPost]
        public ActionResult Create(SOP sop)
        {
            if (ModelState.IsValid)
            {
              
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BureauID = new SelectList(db.Bureaux, "BureauID", "Name", sop.BureauID);
            return View(sop);
        }

        //
        // GET: /SOP/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SOP sop = db.SOPs.Single(s => s.SOPID == id);
            if (sop == null)
            {
                return HttpNotFound();
            }
            ViewBag.BureauID = new SelectList(db.Bureaux, "BureauID", "Name", sop.BureauID);
            return View(sop);
        }

        //
        // POST: /SOP/Edit/5

        [HttpPost]
        public ActionResult Edit(SOP sop)
        {
            if (ModelState.IsValid)
            {
                db.SOPs.Attach(sop);
                db.ObjectStateManager.ChangeObjectState(sop, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BureauID = new SelectList(db.Bureaux, "BureauID", "Name", sop.BureauID);
            return View(sop);
        }

        //
        // GET: /SOP/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SOP sop = db.SOPs.Single(s => s.SOPID == id);
            if (sop == null)
            {
                return HttpNotFound();
            }
            return View(sop);
        }

        //
        // POST: /SOP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SOP sop = db.SOPs.Single(s => s.SOPID == id);
            db.SOPs.DeleteObject(sop);
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