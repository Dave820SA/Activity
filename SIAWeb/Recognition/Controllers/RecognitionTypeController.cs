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
    public class RecognitionTypeController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
 
        [Common.AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Index()
        {
            return View(db.RecognitionTypes.ToList());
        }

        //
        // GET: /RecognitionType/Details/5

        public ActionResult Details(int id = 0)
        {
            RecognitionType recognitiontype = db.RecognitionTypes.Single(r => r.RecognitionTypeId == id);
            if (recognitiontype == null)
            {
                return HttpNotFound();
            }
            return View(recognitiontype);
        }

        //
        // GET: /RecognitionType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RecognitionType/Create

        [HttpPost]
        public ActionResult Create(RecognitionType recognitiontype)
        {
            if (ModelState.IsValid)
            {
                db.RecognitionTypes.AddObject(recognitiontype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recognitiontype);
        }

        //
        // GET: /RecognitionType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RecognitionType recognitiontype = db.RecognitionTypes.Single(r => r.RecognitionTypeId == id);
            if (recognitiontype == null)
            {
                return HttpNotFound();
            }
            return View(recognitiontype);
        }

        //
        // POST: /RecognitionType/Edit/5

        [HttpPost]
        public ActionResult Edit(RecognitionType recognitiontype)
        {
            if (ModelState.IsValid)
            {
                db.RecognitionTypes.Attach(recognitiontype);
                db.ObjectStateManager.ChangeObjectState(recognitiontype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognitiontype);
        }

        //
        // GET: /RecognitionType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecognitionType recognitiontype = db.RecognitionTypes.Single(r => r.RecognitionTypeId == id);
            if (recognitiontype == null)
            {
                return HttpNotFound();
            }
            return View(recognitiontype);
        }

        //
        // POST: /RecognitionType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RecognitionType recognitiontype = db.RecognitionTypes.Single(r => r.RecognitionTypeId == id);
            db.RecognitionTypes.DeleteObject(recognitiontype);
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