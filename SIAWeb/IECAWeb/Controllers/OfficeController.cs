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
    public class OfficeController : Controller
    {
        private OfficeEntities db = new OfficeEntities();

        //
        // GET: /Office/

        public ActionResult Index()
        {
            var ieca_auditoffice = db.IECA_AuditOffice.OrderBy(x => x.Office_Office.Name).Include("Office_Office");
            return View(ieca_auditoffice.ToList());
        }

        //[HttpPost]
        //public ActionResult Index(string _office)
        //{
        //    Response.Redirect(
        //}

        //
        // GET: /Office/Details/5

        public ActionResult Details(int id = 0)
        {
            IECA_AuditOffice ieca_auditoffice = db.IECA_AuditOffice.Single(i => i.AuditOfficeID == id);
            if (ieca_auditoffice == null)
            {
                return HttpNotFound();
            }
            return View(ieca_auditoffice);
        }

        //
        // GET: /Office/Create

        public ActionResult Create()
        {
            var officeList = from o in db.Office_Office
                             where (o.Visible ==true)
                             orderby o.Name
                             select o;

            ViewBag.AuditOfficeID = new SelectList(officeList, "OfficeID", "Name");
            return View();
        }

        //
        // POST: /Office/Create

        [HttpPost]
        public ActionResult Create(IECA_AuditOffice ieca_auditoffice)
        {
            if (ModelState.IsValid)
            {
                db.IECA_AuditOffice.AddObject(ieca_auditoffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuditOfficeID = new SelectList(db.Office_Office, "OfficeID", "Name", ieca_auditoffice.AuditOfficeID);
            return View(ieca_auditoffice);
        }

        //
        // GET: /Office/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IECA_AuditOffice ieca_auditoffice = db.IECA_AuditOffice.Single(i => i.AuditOfficeID == id);
            if (ieca_auditoffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuditOfficeID = new SelectList(db.Office_Office, "OfficeID", "Name", ieca_auditoffice.AuditOfficeID);
            return View(ieca_auditoffice);
        }

        //
        // POST: /Office/Edit/5

        [HttpPost]
        public ActionResult Edit(IECA_AuditOffice ieca_auditoffice)
        {
            if (ModelState.IsValid)
            {
                db.IECA_AuditOffice.Attach(ieca_auditoffice);
                db.ObjectStateManager.ChangeObjectState(ieca_auditoffice, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuditOfficeID = new SelectList(db.Office_Office, "OfficeID", "Name", ieca_auditoffice.AuditOfficeID);
            return View(ieca_auditoffice);
        }

        //
        // GET: /Office/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IECA_AuditOffice ieca_auditoffice = db.IECA_AuditOffice.Single(i => i.AuditOfficeID == id);
            if (ieca_auditoffice == null)
            {
                return HttpNotFound();
            }
            return View(ieca_auditoffice);
        }

        //
        // POST: /Office/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            IECA_AuditOffice ieca_auditoffice = db.IECA_AuditOffice.Single(i => i.AuditOfficeID == id);
            db.IECA_AuditOffice.DeleteObject(ieca_auditoffice);
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