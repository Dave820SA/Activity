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

        //public ActionResult Index()
        //{
        //    var recognizes = db.Recognizes.Include("Award_AwardType").Include("Award_RecognitionType").Include("Office_Office").Include("Person");
        //    return View(recognizes.ToList());
        //}

        public ActionResult Index()
        {
            var rec = from r in db.Recognizes
                      select r;
            rec = rec.OrderByDescending(r => r.IssuedDate).Take(10);

            return View(rec);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Recognition Contacts.";

            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

     
        public ViewResult Search(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == "")
            {
                ViewBag.NameSortParm = "name_desc";
            }
            else
            {
                ViewBag.NameSortParm = "name_aesc";
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var rec = from r in db.Recognizes
                      select r;

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                rec = rec.Where(s => s.Person.LastName.Contains(searchString) || s.Person.FirstName.Contains(searchString)
                                       || s.Award_RecognitionType.Name.Contains(searchString) || s.Person.Badge.Contains(searchString)
                                       || s.Award_AwardType.Name.Contains(searchString));
            }

            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_aesc";
            ViewBag.NameSortParm = sortOrder == "name_aesc" ? "name_desc" : "name_aesc";
            ViewBag.DateSortParm = sortOrder == "date_aesc" ? "date_desc" : "date_aesc";

            var today = DateTime.Today.AddDays(-60);

            switch (sortOrder)
            {
                case "name_desc":
                    rec = rec.OrderByDescending(r => r.Person.LastName).Where(r => r.IssuedDate >= today);
                    break;
                case "name_aesc":
                    rec = rec.OrderBy(r => r.Person.LastName).Where(r => r.IssuedDate >= today);
                    break;
                case "date_aesc":
                    rec = rec.OrderBy(r => r.IssuedDate).Take(100);
                    break;
                default:
                    if (String.IsNullOrEmpty(searchString))
                    {
                        rec = rec.OrderByDescending(r => r.IssuedDate).Take(100);
                    }
                    else
                    {
                        rec = rec.OrderByDescending(r => r.IssuedDate);
                    }
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(rec.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Award/Details/5
        public ActionResult Details(int id = 0)
        {
            Recognize recognize = db.Recognizes.Single(r => r.RecognitionId == id);

            if (recognize == null)
            {
                return HttpNotFound();
            }
            else
            {
                string docpath;
                if (recognize.DocPath == null)
                {
                    docpath = @"/Images/Daniel.pdf";
                }
                else
                {
                    docpath = recognize.DocPath;
                }

                ViewBag.DocPaths = docpath;

            }
            return View(recognize);
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
