using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantBusinessLayer;
using GrantActivity.Models;

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

        //
        // GET: /Daily/Details/5

        public ActionResult Details(int id = 0)
        {
            Grant_Daily grant_daily = db.Grant_Daily.Single(g => g.AdminDailyID == id);
            if (grant_daily == null)
            {
                return HttpNotFound();
            }


            var activity = from a in db.Grant_Activity
                           select a;

            activity = activity.Where(a => a.DailyID == id);

            ViewData["Activities"] = activity;

            return View(grant_daily);
        }
    }
}
