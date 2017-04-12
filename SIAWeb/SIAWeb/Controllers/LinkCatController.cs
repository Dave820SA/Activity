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
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class LinkCatController : Controller
    {
        private WebLinksEntities db = new WebLinksEntities();

        //
        // GET: /LinkCat/
        
        public ActionResult Index()
        {
            return View(db.WebCategories.ToList());
        }

        //
        // GET: /LinkCat/Details/5

        public ActionResult Details(int id = 0)
        {
            WebCategories webcategories = db.WebCategories.Single(w => w.WebCategoriesID == id);
            if (webcategories == null)
            {
                return HttpNotFound();
            }
            return View(webcategories);
        }

        //
        // GET: /LinkCat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LinkCat/Create

        [HttpPost]
        public ActionResult Create(WebCategories webcategories)
        {
            if (ModelState.IsValid)
            {
                db.WebCategories.AddObject(webcategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webcategories);
        }

        //
        // GET: /LinkCat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WebCategories webcategories = db.WebCategories.Single(w => w.WebCategoriesID == id);
            if (webcategories == null)
            {
                return HttpNotFound();
            }
            return View(webcategories);
        }

        //
        // POST: /LinkCat/Edit/5

        [HttpPost]
        public ActionResult Edit(WebCategories webcategories)
        {
            if (ModelState.IsValid)
            {
                db.WebCategories.Attach(webcategories);
                db.ObjectStateManager.ChangeObjectState(webcategories, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webcategories);
        }

        //
        // GET: /LinkCat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WebCategories webcategories = db.WebCategories.Single(w => w.WebCategoriesID == id);
            if (webcategories == null)
            {
                return HttpNotFound();
            }
            return View(webcategories);
        }

        //
        // POST: /LinkCat/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WebCategories webcategories = db.WebCategories.Single(w => w.WebCategoriesID == id);
            db.WebCategories.DeleteObject(webcategories);
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