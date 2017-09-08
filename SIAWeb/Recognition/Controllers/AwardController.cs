using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RecognitionBusinessLayer;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Recognition.Controllers
{
    public class AwardController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        // GET: /Award/
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == "")
            {
                ViewBag.NameSortParm = "name_desc";
            }
            else
            {
                ViewBag.NameSortParm = "name_aesc";
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var rec = from r in db.Recognizes
                      select r;

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                rec = rec.Where(s => s.Person.LastName.Contains(searchString) || s.Person.FirstName.Contains(searchString)
                                       || s.Award_RecognitionType.Name.Contains(searchString) || s.Person.Badge.Contains(searchString)
                                       || s.Award_AwardType.Name.Contains(searchString));
            }

            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_aesc";
            ViewBag.NameSortParm = sortOrder == "name_aesc" ? "name_desc" : "name_aesc";
            ViewBag.DateSortParm = sortOrder == "date_aesc" ? "date_desc" : "date_aesc";
           
            var today = DateTime.Today.AddDays(-60);

            switch (sortOrder)
            {
                case "name_desc":
                    rec = rec.OrderByDescending(r => r.Person.LastName).Where(r => r.IssuedDate >= today);
                    break;
                case "name_aesc":
                    rec = rec.OrderBy(r => r.Person.LastName).Where(r => r.IssuedDate >= today);
                    break;
                case "date_aesc":
                    rec = rec.OrderBy(r => r.IssuedDate).Take(100);
                    break;
                default:
                    if (String.IsNullOrEmpty(searchString))
                    {
                        rec = rec.OrderByDescending(r => r.IssuedDate).Take(100);
                    }
                    else
                    {
                        rec = rec.OrderByDescending(r => r.IssuedDate);
                    }
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(rec.ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult Index()
        //{
        //    var recognizes = db.Recognizes.Include("Award_AwardType").Include("Award_RecognitionType").Include("Office_Office").Include("Person");
        //    return View(recognizes.ToList());
        //}

        //
        // GET: /Award/Details/5

        public ActionResult Details(int id = 0)
        {
            Recognize recognize = db.Recognizes.Single(r => r.RecognitionId == id);

            if (recognize == null)
            {
                return HttpNotFound();
            }
            else
            {
                string docpath ;
                if (recognize.DocPath == null)
                {
                    docpath = @"/Images/Daniel.pdf";
                }
                else
                {
                    docpath = recognize.DocPath;
                }

                ViewBag.DocPaths = docpath;
                
            }
            return View(recognize);
        }

        //
        // GET: /Award/Create

        public ActionResult Create()
        {
            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name");
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name");

            ViewBag.AppEntityID = db.People.OrderBy(p => p.LastName).AsEnumerable().Select(p => new SelectListItem()
            {

                Value = p.AppEntityID.ToString(),
                Text = string.Format("{0} {1} {2} - {3}", p.LastName, p.FirstName,p.Badge, p.OfficeCode).ToUpper()
            });

            ViewBag.OfficeId = db.Offices.OrderBy(p => p.Code).AsEnumerable().Select(p => new SelectListItem()
            {

                Value = p.OfficeID.ToString(),
                Text = string.Format("{0} - {1}", p.Code, p.Name).ToUpper()
            });
            
            return View();
        }

        //
        // POST: /Award/Create

        [HttpPost]
        public ActionResult Create(Recognize recognize)
        {
            //var x = recognize.AppEntityID;
            //var id = db.People.Where(p => p.AppEntityID == x).Select(p => p.OfficeID);

            //Recognize recognizeFromDb = db.Recognizes.Single(y => y.AppEntityID == recognize.AppEntityID);



            if (ModelState.IsValid)
            {
                db.Recognizes.AddObject(recognize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name", recognize.AwardTypeId);
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name", recognize.RecogTypeId);
            ViewBag.OfficeId = new SelectList(db.Offices, "OfficeID", "Name", recognize.OfficeId);
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "FirstName", recognize.AppEntityID);
            return View(recognize);
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
            var path = "";
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string fileExtension = Path.GetExtension(fileName).ToString();

                    fileName = fileName.Replace(" ", string.Empty);

                    dynamic rgPattern = "[\\\\\\/:\\*\\?\"'<>|]";
                    Regex objRegEx = new Regex(rgPattern);

                    fileName = objRegEx.Replace(fileName, "");
                    string filePath = System.Configuration.ConfigurationManager.AppSettings["SavePath"].ToString();

                    path = Path.Combine(filePath, fileName);

                    file.SaveAs(path);

                }

                return RedirectToAction("Create", "Award", new { value1 = path });
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("FileUpload", "Award");
            }
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

            ViewBag.Employee = db.People.Where(p => p.AppEntityID == id).Select(p => p.FullName);

            ViewBag.AwardTypeId = new SelectList(db.AwardTypes, "AwardTypeId", "Name", recognize.AwardTypeId);
            ViewBag.RecogTypeId = new SelectList(db.RecognitionTypes, "RecognitionTypeId", "Name", recognize.RecogTypeId);
            
            ViewBag.OfficeId = new SelectList(db.Offices, "OfficeID", "Name", recognize.OfficeId);
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "FullName", recognize.AppEntityID);
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
            ViewBag.OfficeId = new SelectList(db.Offices, "OfficeID", "Name", recognize.OfficeId);
            ViewBag.AppEntityID = new SelectList(db.People, "AppEntityID", "FirstName", recognize.AppEntityID);
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