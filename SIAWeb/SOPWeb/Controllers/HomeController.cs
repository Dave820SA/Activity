﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SOPBusinessLayer;
using PagedList;

namespace SOPWeb.Controllers
{
    public class HomeController : Controller
    {

        SAPDActivityEntities db = new SAPDActivityEntities();

        [OutputCache(Duration=10)]
        public ActionResult Index()
        {

            List<SOP_vCurrentDoc> sopCurrentDoc = db.SOP_vCurrentDoc.ToList();

            ViewBag.Message = "Welcome to the SOP Web App.";

            return View(sopCurrentDoc);
        }

        //track the clicked links
        public ActionResult updateStats(string link, string page)
        {
            ActivityLog track = new ActivityLog();
            track.WebAppID = 13;
            string appID = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            if (appID != null)
            {
                track.AppEntityID = Int32.Parse(appID);
            }
            track.Link = link;
            track.WebPage = page;
            track.ClickedDatetime = DateTime.Parse(DateTime.Now.ToString());
            track.Flagged = false;

            db.ActivityLogs.AddObject(track);
            db.SaveChanges();

            return View();
        }


        public ActionResult Info()
        {
            return View();
        }

        [OutputCache(Duration = 10)]
        public ViewResult Search(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == "sop_aesc" || sortOrder == "")
            {
                ViewBag.NameSortParm = "sop_desc";
            }
            else
            {
                ViewBag.NameSortParm = "sop_aesc";
            }
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "sop_desc" : "sop_aesc";
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
                case "sop_aesc":
                    sop = sop.OrderBy(s => s.SOP_SOP.Name);
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
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sop.ToPagedList(pageNumber, pageSize));
        }


        //public ActionResult Search()
        //{
        //    ViewBag.Message = "Your Search Page.";

        //    return View();
        //}

        public ActionResult Details(int id = 0)
        {
            DocHistory dochistory = db.DocHistories.Single(d => d.DocHistoryID == id);
            if (dochistory == null)
            {
                return HttpNotFound();
            }
            return View(dochistory);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "SOP Contacts.";

            return View();
        }

        [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "SOP Admin.";

            return View();
        }
    }
}
