using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IECAWeb.Common;
using IECAWeb.Models;

namespace IECAWeb.Controllers
{
    public class HomeController : Controller
    {   
        //get the users office ID to return status about offices in his/her office
        string userOfficeID = (string)System.Web.HttpContext.Current.Session["OfficeID"];
        public ActionResult Index()
        {
            @ViewBag.AuditDate = DateTime.Now.ToShortDateString();
            pageview(Convert.ToInt32(userOfficeID), Convert.ToDateTime(@ViewBag.AuditDate));
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string myMove, string stDate)
        {
            //Assign the new date sent from the page
            @ViewBag.AuditDate = newDate(myMove, stDate);
            pageview(Convert.ToInt32(userOfficeID), Convert.ToDateTime(@ViewBag.AuditDate));
            return View();
        }

        private void pageview(int _officeId, DateTime _date)
        {
            //Assigned Officer stats
            var ao = getAssigned(_officeId);
            //Count of assigned
            ViewBag.AssignedCount = ao.Count();
            //Count of supervisors
            ViewBag.SupAssigned = ao.Count(n => n.jtRanking <= 6);
            //count of detectives
            ViewBag.DetAssigned = ao.Count(n => n.jtRanking == 8 || n.jtRanking == 9);
            //count of other
            ViewBag.OthAssigned = ao.Count(n => n.jtRanking >= 10);

            //Audit stats
            var aut = audits(Convert.ToInt32(_officeId), _date);
            ViewBag.MoName = _date.ToString("MMMM") + " " + _date.ToString("yyyy");
            //Get the count of pending audits for the current month
            ViewBag.Pending = aut.Count(a => a.CaseAuditFlag == null);
            //Get Not Required
            ViewBag.NotRequired = aut.Count(a => a.CaseAuditFlag == false);
            //get Audit complete 
            ViewBag.Completed = aut.Count(a => a.CaseAuditFlag == true);
        }

        private DateTime newDate(string theMove, string stDate)
        {
            DateTime moveDate = Convert.ToDateTime(stDate);
            if (theMove == "Back")
            {
               moveDate = moveDate.AddMonths(-1);
            }
            else
            {
              moveDate =  moveDate.AddMonths(1);
            }

            return moveDate;
        }

        private List<AssignedOfficers> getAssigned(int id)
        {
            GetAssigned ga = new GetAssigned();
            return ga.GetAssignedOfficers(id).ToList();
        }

        private List<Audit> audits(int _officeID, DateTime _date)
        {
            GetAuditStats gas = new GetAuditStats();
            return gas.AuditStats(_officeID, _date);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
