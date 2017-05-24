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
            daily = from d in db.Grant_Daily
                    select d;


            daily = daily.Where(d => d.AppEntityID != userId && (d.ApprovedFlag == false || d.MoreInformationFlag != true))
                                  .OrderByDescending(date => date.EnteredDate);

            return View(daily.ToList());


            
        }

        [HttpPost]
        public ActionResult GiveReview()
        {
           
            return View();
        }
    }
}
