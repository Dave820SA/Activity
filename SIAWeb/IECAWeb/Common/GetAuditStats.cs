using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using PersonnelBusinessLayer;
using IECAWeb.Models;

namespace IECAWeb.Common
{
    public class GetAuditStats
    {
        //PersonBasicContex pc = new PersonBasicContex();
        AuditEntities pc = new AuditEntities();

        public List<Audit> AuditStats(int officeID, DateTime auditDate)
        //public IEnumerable<Audit> AuditStats(int officeID, DateTime auditDate)
        {
            int mo = partOfDate("Month", auditDate);
            int yr = partOfDate("Year", auditDate);

            var myStats = (from au in pc.AuditHistrories
                           where au.OfficeID == officeID && au.InsertDate.Value.Month == mo && au.InsertDate.Value.Year == yr
                           select new Audit
                           {
                               IECAID = au.IECAID,
                               AppEntity = au.AppEntityID,
                               OfficeID = au.OfficeID,
                               CaseAuditFlag = (bool)au.CaseAuditFlag,
                               AuditDate = (DateTime?)au.AuditDate ?? DateTime.Now,
                               InserDate = (DateTime)au.InsertDate
                           });
            return myStats.ToList();
        }

        private int partOfDate(string direct, DateTime mydate)
        {
            int getDatePart;
            if (direct == "Month")
            {
                getDatePart = mydate.Month;
            }
            else
            {
                getDatePart = mydate.Year;
            }

            return getDatePart;

        }
    }
}