using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Controllers

{
    public class PersonnelSearchController : Controller
    {
        PersonnelContext db = new PersonnelContext();
        //
        // GET: /PersonnelSearch/

        public ActionResult Index(string searchFor = "dav")
        {
            if (searchFor != null)
            {
                string s = searchFor;
                var mySearch = GetSearched(s);
                return View(mySearch);
            }
            else
            {
                return View();
            }
            

            
            
        }


        private List<SearchFor> GetSearched(string searchString)
        {
            var myPeople = from p in db.People
                           join u in db.Users on p.AppEntityID equals u.AppEntityID
                           join b in db.BadgeHistories on u.AppEntityID equals b.AppEntityID into nob
                           from nb in nob.DefaultIfEmpty()
                           where nb.EndDate == null && p.LastName.Contains(searchString) || p.FirstName.Contains(searchString) 
                           select new SearchFor { First = p.FirstName, Last = p.LastName, PIN = u.PIN, Badge = nb.Badge };

            return myPeople.ToList();

        }

    }
}
