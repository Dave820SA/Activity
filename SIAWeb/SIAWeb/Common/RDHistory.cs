using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class RDHistory
    {
        PersonnelContext db = new PersonnelContext();

        public List<RD> GetRDHistory(int appEntity)
        {
            var myRDs = from u in db.Users
                           join rdh in db.RDHistories on u.AppEntityID equals rdh.AppEntityID
                           join dayoff in db.DayOffs on rdh.RDID equals dayoff.RDID
                           join p in db.People on rdh.EnteredBy equals p.AppEntityID
                           orderby rdh.StartDate
                           where u.AppEntityID == appEntity
                           select new RD
                           {
                               StartDate = rdh.StartDate,
                               EndDate = (rdh.EndDate ?? DateTime.Now),
                               FirstName = p.FirstName,
                               LastName = p.LastName,
                               DayOff = dayoff.Name
                           };
            return myRDs.ToList();

        }
    }
}