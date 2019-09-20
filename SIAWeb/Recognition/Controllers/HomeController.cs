using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RecognitionBusinessLayer;
using Recognition.Models;
using System.Globalization;
using Recognition.Common;

namespace Recognition.Controllers
{

    public class HomeController : Controller
    {
        private SAPDActivityEntities db = new SAPDActivityEntities();
        private MonthYearManager mm;
        
        public HomeController()
        {
            mm = new MonthYearManager();
        }

        public ActionResult Index()
        {
            PDEmployeeManager em = new PDEmployeeManager();
            //Get the top 10 PD employees that have recieved awards
            //Loads into partial view _Top10Officers
            ViewData["TopAwardEmployee"] = em.TopEmployees();
            //Get the last 15 employees that recieved an award
            //Loads int partial view _LandingLastEntered
            ViewData["Last15Entered"] = em.Last15Entered();

            return View();
        }

        public ActionResult AwardView(int recType, int? MonthNbr, int? YearNbr)
        { 
            ViewBag.Message = recogType(recType);
            
            var months = mm.GetMonthNames();
            //var myYears = MonthYearManager.GetYearNames();
            var myYears = mm.GetYearsByRecType(recType);

          ViewBag.MonthList = new SelectList(months.ToList(), "MonthNbr", "MoName");
          ViewBag.YearList = new SelectList(myYears.ToList(),"YearNbr","YearName");
         
          int mo = (int)DateTime.Now.Month;
          int yr = (int)DateTime.Now.Year;
          int myMonthNbr = (MonthNbr != null) ? (int)MonthNbr : (int)mo;
          int myYearNbr = (YearNbr != null) ? (int)YearNbr : (int)yr;
         
            var rec = from r in db.Award_spRecTypeMonthYear(recType, myMonthNbr, myYearNbr)
                      select r;

            ViewBag.MessageToUser = string.Format("You are viewing all {0} for {1} {2}", ViewBag.Message, monthName(myMonthNbr), myYearNbr);


            return View(rec);
        }

        
        private string recogType(int recType)
        {
            string recognition;
            switch (recType)
            {
                case  1:
                    recognition = "Commendations";
                    break;
                case 2:
                    recognition = "Merits";
                    break;
                case 3:
                    recognition = "Certificate Of Appreciations";
                    break;
                case 4:
                    recognition = "Letter Of Appreciations";
                    break;
                case 5:
                    recognition = "Of The Month";
                    break;
                case 6:
                    recognition = "Oak Farns";
                    break;
                case 7:
                    recognition = "EnC.O.R.E. Awards";
                    break;
                default:
                    recognition = "Annual Awards";
                    break;
            }

            return recognition;
        }

        private string monthName(int monthNbr)
        {

            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(monthNbr);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Recognition Contacts.";
            PDEmployeeManager pdem = new PDEmployeeManager();
            return View(pdem.GetAppAdmins());
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
