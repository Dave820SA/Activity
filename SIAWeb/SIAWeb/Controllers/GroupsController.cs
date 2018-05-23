using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonnelBusinessLayer;

namespace SIAWeb.Controllers
{
    public class GroupsController : Controller
    {
        private PersonnelContext db = new PersonnelContext();

        //
        // GET: /Groups/

        public ActionResult Index()
        {
            return View(db.GroupTitles.ToList());
        }

        //
        // GET: /Groups/Details/5

        public ActionResult Details(int id = 0)
        {
            GroupTitle grouptitle = db.GroupTitles.Single(g => g.GroupTitleID == id);
            if (grouptitle == null)
            {
                return HttpNotFound();
            }
            return View(grouptitle);
        }

        //
        // GET: /Groups/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Groups/Create

        [HttpPost]
        public ActionResult Create(GroupTitle grouptitle)
        {
            if (ModelState.IsValid)
            {
                db.GroupTitles.AddObject(grouptitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grouptitle);
        }

        //
        // GET: /Groups/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GroupTitle grouptitle = db.GroupTitles.Single(g => g.GroupTitleID == id);
            if (grouptitle == null)
            {
                return HttpNotFound();
            }
            return View(grouptitle);
        }

        //
        // POST: /Groups/Edit/5

        [HttpPost]
        public ActionResult Edit(GroupTitle grouptitle)
        {
            if (ModelState.IsValid)
            {
                db.GroupTitles.Attach(grouptitle);
                db.ObjectStateManager.ChangeObjectState(grouptitle, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grouptitle);
        }

        //
        // GET: /Groups/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GroupTitle grouptitle = db.GroupTitles.Single(g => g.GroupTitleID == id);
            if (grouptitle == null)
            {
                return HttpNotFound();
            }
            return View(grouptitle);
        }

        //
        // POST: /Groups/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupTitle grouptitle = db.GroupTitles.Single(g => g.GroupTitleID == id);
            db.GroupTitles.DeleteObject(grouptitle);
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