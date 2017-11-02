using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class GetPeople
    {
        PersonnelContext db = new PersonnelContext();

        public List<People> GetSearched(string searchString)
        {
            var myPeople = from p in db.People
                           join u in db.Users on p.AppEntityID equals u.AppEntityID

                           join w in db.WorkStatusHistories on u.AppEntityID equals w.AppEntityID into wsh
                           from ws in wsh.DefaultIfEmpty()

                           join st in db.WorkStatus on ws.WorkstatusID equals st.WorkStatusID

                           join o in db.OfficeHistories on u.AppEntityID equals o.AppEntityID into uof
                           from uf in uof.DefaultIfEmpty()

                           join of in db.Office_Office on uf.OfficeID equals of.OfficeID

                           join b in db.BadgeHistories on u.AppEntityID equals b.AppEntityID into nob
                           from nb in nob.DefaultIfEmpty()

                           join j in db.JobTitleHistories on u.AppEntityID equals j.AppEntityID into job
                           from jb in job.DefaultIfEmpty()

                           join jth in db.JobTitles on jb.JobTitleID equals jth.JobTitleID
                           
                           where (ws.EndDate == null &&  uf.EndDate == null && nb.EndDate == null && jb.EndDate == null) && (p.LastName.Contains(searchString) || p.FirstName.Contains(searchString)
                           || u.SAP.Contains(searchString) || nb.Badge.Contains(searchString))

                           select new People {AppEntityID = p.AppEntityID, First = p.FirstName, Last = p.LastName, PIN = u.PIN, Badge = nb.Badge,
                           SAP = u.SAP, OfficeID = of.OfficeID, Office = of.Name, OfficeCode = of.Code, JobTitle = jth.Name, jtRanking = (jth.jtRanking ?? 12),
                          RankCode = jth.NameCode, Status = st.Name };

            return myPeople.ToList();

        }

    }
}