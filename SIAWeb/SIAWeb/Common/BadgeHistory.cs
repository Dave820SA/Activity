using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class BadgeHistory
    {
        PersonnelContext db = new PersonnelContext();

        public List<Badge> GetBadgeHistory(int appEntity)
        {
            var myBadges = from u in db.Users
                        join bh in db.BadgeHistories on u.AppEntityID equals bh.AppEntityID
                        join p in db.People on bh.EnteredBy equals p.AppEntityID
                        orderby bh.StartDate
                        where u.AppEntityID == appEntity
                        select new Badge
                        {
                            StartDate = bh.StartDate,
                            EndDate = (bh.EndDate ?? DateTime.Now),
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                             BadgeNbr = bh.Badge
                        };
            return myBadges.ToList();

        }
    } 
}