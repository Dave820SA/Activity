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

        public List<Badges> GetBadgeHistory(int appEntity)
        {
            var myBadges = from u in db.Users
                        join bh in db.BadgeHistories on u.AppEntityID equals bh.AppEntityID
                        join p in db.People on bh.EnteredBy equals p.AppEntityID
                        orderby bh.StartDate
                        where u.AppEntityID == appEntity
                        select new Badges
                        {
                            Start = bh.StartDate,
                            End = (bh.EndDate ?? DateTime.Now),
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                             Badge = bh.Badge
                        };
            return myBadges.ToList();

        }
    } 
}