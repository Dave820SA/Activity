using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecognitionBusinessLayer;

namespace Recognition.Controllers
{
    public class AwardController : Controller
    {
        private SAPDActivityEntities1 db = new SAPDActivityEntities1();

        //
        // GET: /Award/

        public ActionResult Index()
        {
            var recognizes = db.Recognizes.Include("Award_AwardType").Include("Award_RecognitionType").Include("Person").Include("Office_Office");
            return View(recognizes.ToList());
        }

        //
        // GET: /Award/Details/5

        public ActionResult Details(int id = 0)
        {
            Recognize recognize = db.Recognizes.Single(r => r.RecognitionId == id);
            if (recognize == null)
            {
                return HttpNotFound();
            }
            return View(recognize);
        }

        //
        // GET: /Award/Create

        public ActionResult Create()
        {
            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name");
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name");
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "Title");
            ViewBag.OfficeId = new SelectList(db.Office_Office, "OfficeID", "Name");
            return View();
        }

        //
        // POST: /Award/Create

        [HttpPost]
        public ActionResult Create(Recognize recognize)
        {
            if (ModelState.IsValid)
            {
                db.Recognizes.AddObject(recognize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name", recognize.AwardTypeId);
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name", recognize.RecogTypeId);
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "Title", recognize.AppEntityID);
            ViewBag.OfficeId = new SelectList(db.Office_Office, "OfficeID", "Name", recognize.OfficeId);
            return View(recognize);
        }

        //
        // GET: /Award/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Recognize recognize = db.Recognizes.Single(r => r.RecognitionId == id);
            if (recognize == null)
            {
                return HttpNotFound();
            }
            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name", recognize.AwardTypeId);
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name", recognize.RecogTypeId);
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "Title", recognize.AppEntityID);
            ViewBag.OfficeId = new SelectList(db.Office_Office, "OfficeID", "Name", recognize.OfficeId);
            return View(recognize);
        }

        //
        // POST: /Award/Edit/5

        [HttpPost]
        public ActionResult Edit(Recognize recognize)
        {
            if (ModelState.IsValid)
            {
                db.Recognizes.Attach(recognize);
                db.ObjectStateManager.ChangeObjectState(recognize, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name", recognize.AwardTypeId);
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name", recognize.RecogTypeId);
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "Title", recognize.AppEntityID);
            ViewBag.OfficeId = new SelectList(db.Office_Office, "OfficeID", "Name", recognize.OfficeId);
            return View(recognize);
        }

        //
        // GET: /Award/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Recognize recognize = db.Recognizes.Single(r => r.RecognitionId == id);
            if (recognize == null)
            {
                return HttpNotFound();
            }
            return View(recognize);
        }

        //
        // POST: /Award/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognize recognize = db.Recognizes.Single(r => r.RecognitionId == id);
            db.Recognizes.DeleteObject(recognize);
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