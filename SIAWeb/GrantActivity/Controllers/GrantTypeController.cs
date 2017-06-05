using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;

namespace GrantActivity.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class GrantTypeController : Controller
    {
        
        private GrantEntities db = new GrantEntities();

        //
        // GET: /GrantType/

        public ActionResult Index()
        {
            return View(db.Grant_GrantType.ToList());
        }

        //
        // GET: /GrantType/Details/5

        public ActionResult Details(int id = 0)
        {
            Grant_GrantType grant_granttype = db.Grant_GrantType.Single(g => g.GrantTypeID == id);
            if (grant_granttype == null)
            {
                return HttpNotFound();
            }
            return View(grant_granttype);
        }

        //
        // GET: /GrantType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GrantType/Create

        [HttpPost]
        public ActionResult Create(Grant_GrantType grant_granttype)
        {
            if (ModelState.IsValid)
            {
                db.Grant_GrantType.AddObject(grant_granttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grant_granttype);
        }

        //
        // GET: /GrantType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Grant_GrantType grant_granttype = db.Grant_GrantType.Single(g => g.GrantTypeID == id);
            if (grant_granttype == null)
            {
                return HttpNotFound();
            }
            return View(grant_granttype);
        }

        //
        // POST: /GrantType/Edit/5

        [HttpPost]
        public ActionResult Edit(Grant_GrantType grant_granttype)
        {
            if (ModelState.IsValid)
            {
                db.Grant_GrantType.Attach(grant_granttype);
                db.ObjectStateManager.ChangeObjectState(grant_granttype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grant_granttype);
        }

        //
        // GET: /GrantType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Grant_GrantType grant_granttype = db.Grant_GrantType.Single(g => g.GrantTypeID == id);
            if (grant_granttype == null)
            {
                return HttpNotFound();
            }
            return View(grant_granttype);
        }

        //
        // POST: /GrantType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grant_GrantType grant_granttype = db.Grant_GrantType.Single(g => g.GrantTypeID == id);
            db.Grant_GrantType.DeleteObject(grant_granttype);
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