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
    public class GroupMemberController : Controller
    {
        private PersonnelContext db = new PersonnelContext();

        //
        // GET: /GroupMember/

        public ActionResult Index()
        {
            var groupmembers = db.GroupMembers.Include("User_User").Include("User_GroupTitle");
            return View(groupmembers.ToList());
        }

        //
        // GET: /GroupMember/Details/5

        public ActionResult Details(int id = 0)
        {
            GroupMember groupmember = db.GroupMembers.Single(g => g.GroupMemberID == id);
            if (groupmember == null)
            {
                return HttpNotFound();
            }
            return View(groupmember);
        }

        //
        // GET: /GroupMember/Create

        public ActionResult Create()
        {
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN");
            ViewBag.GroupTitleID = new SelectList(db.GroupTitles, "GroupTitleID", "Name");
            return View();
        }

        //
        // POST: /GroupMember/Create

        [HttpPost]
        public ActionResult Create(GroupMember groupmember)
        {
            if (ModelState.IsValid)
            {
                db.GroupMembers.AddObject(groupmember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", groupmember.AppEntityID);
            ViewBag.GroupTitleID = new SelectList(db.GroupTitles, "GroupTitleID", "Name", groupmember.GroupTitleID);
            return View(groupmember);
        }

        //
        // GET: /GroupMember/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GroupMember groupmember = db.GroupMembers.Single(g => g.GroupMemberID == id);
            if (groupmember == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", groupmember.AppEntityID);
            ViewBag.GroupTitleID = new SelectList(db.GroupTitles, "GroupTitleID", "Name", groupmember.GroupTitleID);
            return View(groupmember);
        }

        //
        // POST: /GroupMember/Edit/5

        [HttpPost]
        public ActionResult Edit(GroupMember groupmember)
        {
            if (ModelState.IsValid)
            {
                db.GroupMembers.Attach(groupmember);
                db.ObjectStateManager.ChangeObjectState(groupmember, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Details", "Groups", new { @Id = groupmember.GroupTitleID });
                //return RedirectToAction("Index");
            }
            ViewBag.AppEntityID = new SelectList(db.Users, "AppEntityID", "PIN", groupmember.AppEntityID);
            ViewBag.GroupTitleID = new SelectList(db.GroupTitles, "GroupTitleID", "Name", groupmember.GroupTitleID);
            return View(groupmember);
        }

        //
        // GET: /GroupMember/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GroupMember groupmember = db.GroupMembers.Single(g => g.GroupMemberID == id);
            if (groupmember == null)
            {
                return HttpNotFound();
            }
            return View(groupmember);
        }

        //
        // POST: /GroupMember/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupMember groupmember = db.GroupMembers.Single(g => g.GroupMemberID == id);
            db.GroupMembers.DeleteObject(groupmember);
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