using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RecognitionBusinessLayer;

namespace Recognition.Controllers
{

     

    public class HomeController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Recognition Contacts.";

            return View();
        }


        [OutputCache(Duration = 10)]
        public ViewResult Search(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == "rec_aesc" || sortOrder == "")
            {
                ViewBag.NameSortParm = "rec_desc";
            }
            //else
            //{
            //    ViewBag.NameSortParm = "rec_aesc";
            //}
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "sop_desc" : "sop_aesc";
            ViewBag.DateSortParm = sortOrder == "IssueDate" ? "date_desc" : "IssueDate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var rec = from s in db.Recognizes.OrderByDescending(s => s.IssuedDate)
                      select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                rec = rec.Where(s => s.Person.LastName.Contains(searchString) || s.Person.FirstName.Contains(searchString)
                                       || s.Award_RecognitionType.Name.Contains(searchString) || s.Person.Badge.Contains(searchString)
                                       || s.Award_AwardType.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "rec_desc":
                    rec = rec.OrderByDescending(s => s.Award_RecognitionType.Name).Take(100);
                    break;
                case "rec_aesc":
                    rec = rec.OrderBy(s => s.Award_RecognitionType.Name).Take(100);
                    break;
                case "StartDate":
                    rec = rec.OrderBy(s => s.IssuedDate).Take(100);
                    break;
                case "date_desc":
                    rec = rec.OrderByDescending(s => s.IssuedDate).Take(100);
                    break;
                default:
                    if (sortOrder == null && searchString != null )
                    {
                        rec = rec.OrderByDescending(s => s.IssuedDate);
                    }
                    else
                    {
                        rec = rec.OrderByDescending(s => s.IssuedDate).Take(100);
                    }
                    
                    break;
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(rec.ToPagedList(pageNumber, pageSize));
        }



        [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "SOP Admin.";

            return View();
        }

        public ActionResult NonUser()
        {
            return View();
        }


    }
}
