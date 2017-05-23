using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrantActivity.Models;

namespace GrantActivity.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiveReview(RatingAndReviews model)
        {
            model.InsertRating(model.UserId, model.RatingStar, model.ConsumerName, model.ReviewHeader, model.ReviewContent);
            return View("SubmittedReview", model);
        }
    }
}
