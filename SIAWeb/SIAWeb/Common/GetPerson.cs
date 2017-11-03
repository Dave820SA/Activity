using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    
    public class GetPerson
    {
        PersonnelContext db = new PersonnelContext();
        public List<PersonInfo> GetPersonInfo(int appEntityID)
        {
            //IEnumerable<PersonInfo> newPerson;

            var newPerson = (from p in db.People

                           join u in db.Users on p.AppEntityID equals u.AppEntityID

                           join w in db.WorkStatusHistories on u.AppEntityID equals w.AppEntityID into wsh
                           from ws in wsh.DefaultIfEmpty()

                           join wst in db.WorkStatus on ws.WorkstatusID equals wst.WorkStatusID

                           join o in db.OfficeHistories on u.AppEntityID equals o.AppEntityID into uof
                           from uf in uof.DefaultIfEmpty()

                           join of in db.Office_Office on uf.OfficeID equals of.OfficeID

                           join b in db.BadgeHistories on u.AppEntityID equals b.AppEntityID into nob
                           from nb in nob.DefaultIfEmpty()

                           join j in db.JobTitleHistories on u.AppEntityID equals j.AppEntityID into job
                           from jb in job.DefaultIfEmpty()

                           join jth in db.JobTitles on jb.JobTitleID equals jth.JobTitleID

                           join a in db.P_Address on p.AppEntityID equals a.AppEntityID into add
                           from ad in add.DefaultIfEmpty()

                           join adType in db.AddressTypes on ad.AddressTypeID equals adType.AddressTypeID into addt
                           from adt in addt.DefaultIfEmpty()

                           join s in db.States on ad.StateID equals s.StateID into stt
                           from st in stt.DefaultIfEmpty()

                           orderby p.LastName, p.FirstName

                           where (ws.EndDate == null && uf.EndDate == null && nb.EndDate == null && jb.EndDate == null && ad.EndDate == null) && (p.AppEntityID == appEntityID)

                           select new PersonInfo
                           {
                               AppEntityID = p.AppEntityID,
                               First = p.FirstName,
                               Last = p.LastName,
                               PIN = u.PIN,
                               Badge = nb.Badge,
                               SAP = u.SAP,
                               OfficeID = of.OfficeID,
                               Office = of.Name,
                               OfficeCode = of.Code,
                               JobTitle = jth.Name,
                               jtRanking = (jth.jtRanking ?? 12),
                               RankCode = jth.NameCode,
                               Status = wst.Name,
                               AdressL1 = ad.AddressLine1,
                               AddressL2 = ad.AddressLine2,
                               City = ad.City,
                               Zip = ad.PostalCode,
                               State = st.StateName,
                               AddressType = adt.Name,
                               Badges = (from us in db.Users
                                            join bh in db.BadgeHistories on us.AppEntityID equals bh.AppEntityID
                                            join pr in db.People on bh.EnteredBy equals pr.AppEntityID
                                            orderby bh.StartDate
                                            where us.AppEntityID == appEntityID
                                            select new Badge
                                            {
                                                StartDate = bh.StartDate,
                                                EndDate = (bh.EndDate ?? DateTime.Now),
                                                FirstName = pr.FirstName,
                                                LastName = pr.LastName,
                                                BadgeNbr = bh.Badge
                                            })
                           });

            //var myBadges = from u in db.Users
            //               join bh in db.BadgeHistories on u.AppEntityID equals bh.AppEntityID
            //               join p in db.People on bh.EnteredBy equals p.AppEntityID
            //               orderby bh.StartDate
            //               where u.AppEntityID == appEntityID
            //               select new Badge
            //               {
            //                   StartDate = bh.StartDate,
            //                   EndDate = (bh.EndDate ?? DateTime.Now),
            //                   FirstName = p.FirstName,
            //                   LastName = p.LastName,
            //                   BadgeNbr = bh.Badge
            //               };
           

            return newPerson.ToList();
        }

    }
}