using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class PersonWorkProfileGet
    {
         PersonnelContext db = new PersonnelContext();
         public List<PersonWorkProfile> GetPersonInfo(int appEntityID)
         {
             var newPWProfile = (from p in db.People
                                 join u in db.Users on p.AppEntityID equals u.AppEntityID
                                 join o in db.Office_Office on u.OfficeID equals o.OfficeID
                                 join ws in db.WorkStatus on u.WorkStatusID equals ws.WorkStatusID
                                 join rd in db.DayOffs on u.RDID equals rd.RDID
                                 join s in db.Shifts on u.ShiftID equals s.ShiftID
                                 where p.AppEntityID == appEntityID
                                 select new PersonWorkProfile
                                 {
                                     AppEntityID = p.AppEntityID,
                                     SAP = u.SAP,
                                     OfficeID = o.OfficeID,
                                     OfficeCode = o.Code,
                                     Office = o.Name,
                                     Status = ws.Name,
                                     RD = rd.Name,
                                     Shift = s.Name,
                                     Employeed = u.HireDate,

                                     Emails = (from ep in db.People
                                               join e in db.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                               join et in db.p_EmailAddressType on e.EmailAddressTypeID equals et.EmailAddressTypeID
                                               where ep.AppEntityID == appEntityID
                                               select new EmailAddress
                                               {
                                                   AddressType = et.Name,
                                                   userEmailAddress = e.EmailAddress
                                               }),

                                     PhoneNumbers = (from pp in db.People
                                                     join ph in db.PersonPhones on pp.AppEntityID equals ph.AppEntityID
                                                     join phType in db.PhoneNumberTypes on ph.PhoneNumberTypeID equals phType.PhoneNumberTypeID
                                                     where ph.AppEntityID == appEntityID
                                                     select new PhoneNumber
                                                     {
                                                         PhoneType = phType.Name,
                                                         PhoneNbr = ph.PhoneNumber
                                                     }),
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
                                     OfficeAssigments = (from us in db.Users
                                                         join oh in db.OfficeHistories on us.AppEntityID equals oh.AppEntityID
                                                         join of in db.Office_Office on oh.OfficeID equals of.OfficeID
                                                         orderby oh.StartDate
                                                         where oh.AppEntityID == appEntityID
                                                         select new OfficeAssigment
                                                         {
                                                             OfficeID = oh.OfficeID,
                                                             StartDate = oh.StartDate,
                                                             EndDate = (oh.EndDate ?? DateTime.Now),
                                                             Office = of.Name,
                                                             OfficeCode = of.Code
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
                                                 })

                                 });

             return newPWProfile.ToList();

         }

    }
}