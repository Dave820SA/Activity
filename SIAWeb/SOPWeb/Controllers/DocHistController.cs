using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SOPBusinessLayer;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
//using SOPWeb.Models.SOPDocUpload;

namespace SOPWeb.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class DocHistController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();

        //
        // GET: /DocHist/

        public ActionResult Index()
        {
            //var dochistories = db.DocHistories.Include("SOP_SOP");
            var dochistories = db.DocHistories.Where(d => d.EndDate == null).OrderByDescending(d => d.ModifiedDate);
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

                return RedirectToAction("Create", "DocHist", new { value1 = path });
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("FileUpload", "DocHist");
            }
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