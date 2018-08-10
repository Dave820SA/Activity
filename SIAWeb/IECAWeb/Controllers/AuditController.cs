using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using IECAWeb.Models;
using IECAWeb.Common;
using System.Globalization;

namespace IECAWeb.Controllers
{

    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin, Supervisor")]
    public class AuditController : Controller
    {
        private AuditEntities db = new AuditEntities();

        public ActionResult Index(int id)
        {
            //automatically Enter officers into the table that belong to the office
            enterAuditOfficers(id, DateTime.Now.ToShortDateString());
            var audithistrories = auditHistory(id, DateTime.Now);

            ViewBag.OfficeID = id;
            ViewBag.MyDate = DateTime.Now;
            ViewBag.MyMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " + DateTime.Now.Year.ToString();
            
            return View(audithistrories.ToList());
        }

        [HttpPost]
        public ActionResult Index(int id, DateTime dtDate, string myMove)
        {
            if (myMove == "Back")
            {
                dtDate = moBack(dtDate);
            }
            else
            {
                dtDate = moForward(dtDate);
            }

            ViewBag.OfficeID = id;
            ViewBag.MyDate = dtDate;
            ViewBag.MyMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtDate.Month) + " " + dtDate.Year.ToString();
            var audithistrories = auditHistory(id, dtDate);
            return View(audithistrories.ToList());
        }

        private void enterAuditOfficers(int officeID, string auditDate)
        {
            var noReturn = db.spEnterAuditOfficers(officeID, auditDate);
        }

        private DateTime moBack(DateTime myDate)
        {
            return  myDate.AddMonths(-1);
        }

        private DateTime moForward(DateTime myDate)
        {
            return myDate.AddMonths(1);
        }

        private IList<AuditHistrory> auditHistory(int office, DateTime myDate)
        {
            int mo = partOfDate("Month", myDate);
            int yr = partOfDate("Year", myDate);

            var history = from d in db.AuditHistrories
                          where d.InsertDate.Value.Year == yr && d.InsertDate.Value.Month == mo && d.OfficeID == office
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

        public ActionResult SelectedOfficer(int id)
        {
            GetAuditStats gas = new GetAuditStats();
            @ViewData["OfficerAudits"] = gas.OfficerAuditStats(id).OrderByDescending(d => d.IECAID);
            PersonBasicGet pg = new PersonBasicGet();
            return View(pg.GetPersonPasicInfo(id));
        }

        [HttpGet]
        public ActionResult GeneralNotes(int auditId)
        {
            GetGeneralNotes ggn = new GetGeneralNotes();
            var generalNotes = ggn.AuditNotes(auditId);
            return PartialView("_GeneralNotes",generalNotes);
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

        public ActionResult Create()
        {
            ViewBag.AppEntityID = new SelectList(db.AppEntities, "AppEntityID", "AppEntityID");
            return View();
        }

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

        [HttpPost]
        public ActionResult AddGenNotes(AuditNotes _notes, int id)
        {
            Sup_AuditNotes san = new Sup_AuditNotes();
         
            san.NoteTypeID = _notes.NoteTypeID;
            san.AuditHistID = _notes.AuditHistID;
            san.AuditNotes = _notes.AuditNote;
            san.NoteByID = _notes.NoteByID;
            san.NoteDate = _notes.NoteDate ?? DateTime.Now ;
            san.FollowupFlag = _notes.Followup ?? false;

            db.Sup_AuditNotes.AddObject(san);
            db.SaveChanges();

            return RedirectToAction("Audit", "index"); 
        }

        public ActionResultAllNotes()
        {
            List<AuditNotes> model = new List<AuditNotes>
            return PartialView("_AddGenNotes", model);
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
            ViewBag.Auditor = (string)System.Web.HttpContext.Current.Session["AppEntityID"]; 
            ViewBag.AppEntityID = new SelectList(db.AppEntities, "AppEntityID", "AppEntityID", audithistrory.AppEntityID);
            return View(audithistrory);
        }

        //
        // POST: /Audit/Edit/5

        [HttpPost]
        public ActionResult Edit(AuditHistrory audithistrory, int officeID)
        {
            if (ModelState.IsValid)
            {
                //var officeID = audithistrory.OfficeID;
                db.AuditHistrories.Attach(audithistrory);
                db.ObjectStateManager.ChangeObjectState(audithistrory, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index/" + audithistrory.OfficeID + "");
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