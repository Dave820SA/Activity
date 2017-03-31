using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWebLinksBusinessLayer;

namespace SIAWeb.Controllers
{
    public class LinkAddressController : Controller
    {
        private WebLinksEntities db = new WebLinksEntities();

        //
        // GET: /LinkAddress/

        public ActionResult Index()
        {
            var weblinks = db.WebLinks.Include("SIA_WebCategories");
            return View(weblinks.ToList());
        }

        //
        // GET: /LinkAddress/Details/5

        public ActionResult Details(int id = 0)
        {
            WebLinks weblinks = db.WebLinks.Single(w => w.WebLinkID == id);
            if (weblinks == null)
            {
                return HttpNotFound();
            }
            return View(weblinks);
        }

        //
        // GET: /LinkAddress/Create

        public ActionResult Create()
        {
            ViewBag.WebCategoryID = new SelectList(db.WebCategories, "WebCategoriesID", "Name");
            return View();
        }

        //
        // POST: /LinkAddress/Create

        [HttpPost]
        public ActionResult Create(WebLinks weblinks)
        {
            if (ModelState.IsValid)
            {
                db.WebLinks.AddObject(weblinks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WebCategoryID = new SelectList(db.WebCategories, "WebCategoriesID", "Name", weblinks.WebCategoryID);
            return View(weblinks);
        }

        //
        // GET: /LinkAddress/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WebLinks weblinks = db.WebLinks.Single(w => w.WebLinkID == id);
            if (weblinks == null)
            {
                return HttpNotFound();
            }
            ViewBag.WebCategoryID = new SelectList(db.WebCategories, "WebCategoriesID", "Name", weblinks.WebCategoryID);
            return View(weblinks);
        }

        //
        // POST: /LinkAddress/Edit/5

        [HttpPost]
        public ActionResult Edit(WebLinks weblinks)
        {
            if (ModelState.IsValid)
            {
                db.WebLinks.Attach(weblinks);
                db.ObjectStateManager.ChangeObjectState(weblinks, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WebCategoryID = new SelectList(db.WebCategories, "WebCategoriesID", "Name", weblinks.WebCategoryID);
            return View(weblinks);
        }

        //
        // GET: /LinkAddress/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WebLinks weblinks = db.WebLinks.Single(w => w.WebLinkID == id);
            if (weblinks == null)
            {
                return HttpNotFound();
            }
            return View(weblinks);
        }

        //
        // POST: /LinkAddress/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WebLinks weblinks = db.WebLinks.Single(w => w.WebLinkID == id);
            db.WebLinks.DeleteObject(weblinks);
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