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

                           join r in db.RDHistories on u.AppEntityID equals r.AppEntityID into crd
                           from curRd in crd.DefaultIfEmpty()

                           join dayo in db.DayOffs on curRd.RDID equals dayo.RDID

                           join s in db.ShiftHistories on u.AppEntityID equals s.AppEntityID into shh
                           from sh in shh.DefaultIfEmpty()

                           join csh in db.Shifts on sh.ShiftID equals csh.ShiftID

                           join a in db.P_Address on p.AppEntityID equals a.AppEntityID into add
                           from ad in add.DefaultIfEmpty()

                           join adType in db.AddressTypes on ad.AddressTypeID equals adType.AddressTypeID into addt
                           from adt in addt.DefaultIfEmpty()

                           join s in db.States on ad.StateID equals s.StateID into stt
                           from st in stt.DefaultIfEmpty()

                           

                           //join eml in db.P_EmailAddress on p.AppEntityID equals eml.AppEntityID

                           orderby p.LastName, p.FirstName

                           where (ws.EndDate == null && uf.EndDate == null && nb.EndDate == null && jb.EndDate == null && ad.EndDate == null && curRd.EndDate == null && sh.EndDate == null) && (p.AppEntityID == appEntityID)

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
                               RD = dayo.Name,
                               Shift = csh.Name,
                               Employeed = (DateTime)u.HireDate,
                               
                               //Email = eml.EmailAddress,
                               Badges = (from us in db.Users
                                            join bh in db.BadgeHistories on us.AppEntityID equals bh.AppEntityID
                                            //join pr in db.People on bh.EnteredBy equals pr.AppEntityID
                                            orderby bh.StartDate
                                            where bh.AppEntityID == appEntityID
                                            select new Badge
                                            {
                                                StartDate = bh.StartDate,
                                                EndDate = (bh.EndDate ?? DateTime.Now),
                                                //FirstName = pr.FirstName,
                                                //LastName = pr.LastName,
                                                BadgeNbr = bh.Badge
                                            }),
                               RDs = (from us in db.Users
                                            join rdh in db.RDHistories on us.AppEntityID equals rdh.AppEntityID
                                            join dayoff in db.DayOffs on rdh.RDID equals dayoff.RDID
                                            //join pr in db.People on rdh.EnteredBy equals p.AppEntityID
                                            orderby rdh.StartDate
                                            where rdh.AppEntityID == appEntityID
                                            select new RD
                                                {
                                                    StartDate = rdh.StartDate,
                                                    EndDate = (rdh.EndDate ?? DateTime.Now),
                                                    //FirstName = p.FirstName,
                                                    //LastName = p.LastName,
                                                    DayOff = dayoff.Name
                                                }),
                            Emails = (from ep in db.People
                                          join e in db.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                          join et in db.p_EmailAddressType on e.EmailAddressTypeID equals et.EmailAddressTypeID
                                          where ep.AppEntityID == appEntityID
                                          select new EmailAddress
                                          { AddressType = et.Name,
                                            userEmailAddress = e.EmailAddress
                                          }),
                            OfficeAssigments = (from us in db.Users
                                            join oh in db.OfficeHistories on us.AppEntityID equals oh.AppEntityID
                                            join o in db.Office_Office on oh.OfficeID equals o.OfficeID
                                            orderby oh.StartDate
                                            where oh.AppEntityID == appEntityID
                                            select new OfficeAssigment
                                            {
                                                StartDate = oh.StartDate,
                                                EndDate = (oh.EndDate ?? DateTime.Now),
                                                Office = o.Name,
                                                OfficeCode = o.Code
                                            }),
                           PhoneNumbers = (from pp in db.People
                                      join ph in db.PersonPhones on pp.AppEntityID equals ph.AppEntityID
                                      join phType in db.PhoneNumberTypes on ph.PhoneNumberTypeID equals phType.PhoneNumberTypeID
                                      //join pr in db.People on rdh.EnteredBy equals p.AppEntityID
                                      //orderby rdh.StartDate
                                      where ph.AppEntityID == appEntityID
                                      select new PhoneNumber
                                      {
                                          PhoneType = phType.Name,
                                          PhoneNbr = ph.PhoneNumber
                                      }),

                               myAwards = (from pawr in db.People
                                         join aw in db.Awards on pawr.AppEntityID equals aw.AppEntityID into awar
                                         from aww in awar.DefaultIfEmpty()

                                         join rt in db.RecognitionTypes on aww.RecogTypeId equals rt.RecognitionTypeId 
                                         

                                         where pawr.AppEntityID == appEntityID
                                         select new UserAward
                                         {
                                               DocPath = aww.DocPath,
                                               AwardName = rt.Name,
                                                IssuedDate = aww.IssuedDate
                                         }),

                           });

            //join aw in db.Awards on p.AppEntityID equals aw.AppEntityID into awar
            //from aww in awar.DefaultIfEmpty()

            //join rt in db.RecognitionTypes on aww.RecogTypeId equals rt.RecognitionTypeId



            return newPerson.ToList();
        }

    }
}