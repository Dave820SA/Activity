using System;
using System.Collections.Generic;
using System.Linq;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class ShiftHistory
    {
        PersonnelContext db = new PersonnelContext();

        public List<Shifts> GetShiftHistory(int appEntity)
        {
            var myShifts = from u in db.Users
                           join sh in db.ShiftHistories on u.AppEntityID equals sh.AppEntityID
                           join s in db.Shifts on sh.ShiftID equals s.ShiftID
                           join p in db.People on sh.EnteredBy equals p.AppEntityID
                           orderby sh.StartDate
                           where u.AppEntityID == appEntity
                           select new Shifts
                           {
                               Start = sh.StartDate,
                               End = (sh.EndDate ?? DateTime.Now),
                               FirstName = p.FirstName,
                               LastName = p.LastName,
                               Shift = s.Name
                           };
            return myShifts.ToList();

        }
    }
}