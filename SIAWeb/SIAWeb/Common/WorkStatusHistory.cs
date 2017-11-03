using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class WorkStatusHistory
    {
        PersonnelContext db = new PersonnelContext();

        public List<WorkStatuss> GetWorkStatusHistory(int appEntity)
        {
            var myStatus = from u in db.Users
                           join ws in db.WorkStatusHistories on u.AppEntityID equals ws.AppEntityID
                           join s in db.WorkStatus on ws.WorkstatusID equals s.WorkStatusID
                           orderby ws.StartDate
                           where u.AppEntityID == appEntity
                           select new WorkStatuss
                           {
                               Start = ws.StartDate,
                               End = (ws.EndDate ?? DateTime.Now),
                               StatusInfo = ws.StatusInfo,
                               LastUpdate = (ws.ModifiedDate ?? DateTime.Now),
                               WorkStatus = s.Name
                           };
            return myStatus.ToList();

        }
    }
}