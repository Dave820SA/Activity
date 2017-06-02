using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;
using GrantActivity.Models;
using System.Data;

namespace GrantActivity.Controllers
{
    public class AdminController : Controller
    {
        private GrantEntities db = new GrantEntities();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var daily = from d in db.Grant_Daily
                        select d;

            daily = daily.Where(d => d.AppEntityID != userId && (d.ApprovedFlag == false || d.MoreInformationFlag != false))
                                  .OrderByDescending(date => date.EnteredDate);

            return View(daily.ToList());

        }

        [HttpPost]
        public ActionResult Index(string Answer)
        {
            int userId = Convert.ToInt32(System.Web.HttpContext.Current.Session["AppEntityID"]);

            var dailyactivities = from d in db.Grant_Daily.Where(d => d.AppEntityID != userId)
                                  select d;

            switch (Answer)
            {
                case "Last30":
                    var baseline = DateTime.Now.AddDays(-30);
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.EnteredDate >= baseline)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "Approve":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.ApprovedFlag == true)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "NotApprove":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.ApprovedFlag == false)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "MoreInfo":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.MoreInformationFlag == true)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                case "All":
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
                default:
                    dailyactivities = dailyactivities.Where(d => d.AppEntityID != userId && d.ApprovedFlag == false)
                        .OrderByDescending(date => date.EnteredDate);
                    break;
            }


            return View(dailyactivities.ToList());
        }

        //
        // GET: /Daily/Details/5
        //[HttpGet]
        public ActionResult Details(int id = 0)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            if (grant_daily == null )
            {
                //return HttpNotFound();
                return Redirect("Index");
            }

            var activity = from a in db.Grant_Activity
                           select a;

            activity = activity.Where(a => a.DailyID == id);

            ViewData["Activities"] = activity;

            return View(grant_daily);
        }


        //Approve items
        public void approve(int id)
        {
            var approv = db.Grant_Daily.FirstOrDefault(x => x.AdminDailyID == id);

            approv.ApprovedFlag = true;
            approv.MoreInformationFlag = false;
            string user = (string)System.Web.HttpContext.Current.Session["AppEntityID"];
            approv.ApprovedByID = int.Parse(user);
            approv.ApprovedDate = DateTime.Now;

            db.SaveChanges();

            RedirectToAction("Index", "Admin");
        }

        //Ask the user for more information
        public void moreInfo(string info, int id)
        {
            var approv = db.Grant_Daily.FirstOrDefault(x => x.AdminDailyID == id);
            approv.MoreInformationFlag = true;
            approv.AdminNotes = info;
            db.SaveChanges();

        }

    }
}
