using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SOPBusinessLayer;

namespace SOPWeb.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class DocHistController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
        // GET: /DocHist/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "sop_desc" : "";
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

            var sop = from s in db.DocHistories.Where(s => s.EndDate == null)
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sop = sop.Where(s => s.SOP_SOP.Name.Contains(searchString)
                                       || s.DocInfo.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "sop_desc":
                    sop = sop.OrderByDescending(s => s.SOP_SOP.Name);
                    break;
                case "StartDate":
                    sop = sop.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    sop = sop.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    sop = sop.OrderBy(s => s.StartDate);
                    break;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(sop.ToPagedList(pageNumber, pageSize));
        }


        public ViewResult Search(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "sop_desc" : "";
            ViewBag.StartDateSortParm = sortOrder == "StartDate" ? "date_desc" : "StartDate";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "enddate_desc" : "EndDate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var sop = from s in db.DocHistories
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sop = sop.Where(s => s.SOP_SOP.Name.Contains(searchString)
                                       || s.DocInfo.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "sop_desc":
                    sop = sop.OrderByDescending(s => s.SOP_SOP.Name);
                    break;
                case "StartDate":
                    sop = sop.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    sop = sop.OrderByDescending(s => s.StartDate);
                    break;
                case "EndDate":
                    sop = sop.OrderBy(s => s.EndDate);
                    break;
                case "enddate_desc":
                    sop = sop.OrderByDescending(s => s.EndDate);
                    break;
                default:
                    sop = sop.OrderBy(s => s.StartDate);
                    break;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(sop.ToPagedList(pageNumber, pageSize));
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


        public ActionResult DetailsAll(int id = 0)
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


        public ActionResult FileUpload()
        {
            return View();
        }

        //
        // POST: /DocHist/Create

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            //var path = "";
            //try
            //{
                //if (file.ContentLength > 0)
               
                //{
                    var fileName = Path.GetFileName(file.FileName);
                    string fileExtension = Path.GetExtension(fileName).ToString();

                    fileName = fileName.Replace(" ", string.Empty);

                    dynamic rgPattern = "[\\\\\\/:\\*\\?\"'<>|]";
                    Regex objRegEx = new Regex(rgPattern);

                    fileName = objRegEx.Replace(fileName, "");
                    string filePath = System.Configuration.ConfigurationManager.AppSettings["SavePath"].ToString();

                    var path = Path.Combine(filePath, fileName);

                    file.SaveAs(path);
                    
                //}

                return RedirectToAction("Create", "DocHist", new { value1 = path });
            //}
            //catch
            //{
            //    ViewBag.Message = "Upload failed";
            //    return RedirectToAction("FileUpload", "DocHist");
            //}
        }



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