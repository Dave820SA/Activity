using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SOPBusinessLayer;
using PagedList;
using SOPWeb.Common;

namespace SOPWeb.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class SOPController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
        // GET: /SOP/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "sop_desc" : "";
            ViewBag.BureauSortParm = String.IsNullOrEmpty(sortOrder) ? "bureau_desc" : "";
            ViewBag.DateSortParm = sortOrder == "LastUpdate" ? "date_desc" : "LastUpdate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            var sop = from s in db.SOPs
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sop = sop.Where(s => s.Name.Contains(searchString)
                                       || s.Office_Bureau.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "sop_desc":
                    sop = sop.OrderByDescending(s => s.Name);
                    break;
                case "bureau_desc":
                    sop = sop.OrderByDescending(s => s.Office_Bureau.Name);
                    break;
                case "LastUpdate":
                    sop = sop.OrderBy(s => s.ModifiedDate);
                    break;
                case "date_desc":
                    sop = sop.OrderByDescending(s => s.ModifiedDate);
                    break;
                default:
                    sop = sop.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(sop.ToPagedList(pageNumber, pageSize));
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
                db.SOPs.AddObject(sop);
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