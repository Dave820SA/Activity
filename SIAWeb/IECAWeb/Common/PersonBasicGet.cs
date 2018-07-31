using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonnelBusinessLayer;
using IECAWeb.Models;

namespace IECAWeb.Common
{
    public class PersonBasicGet
    {
        PersonnelContext db = new PersonnelContext();

        public List<PersonBasic> GetPersonPasicInfo(int appEntityID)
        {
            var myPersonBasic = (from p in db.People
                                 join u in db.Users on p.AppEntityID equals u.AppEntityID
                                 join jt in db.JobTitles on u.JobTitleID equals jt.JobTitleID
                                 join o in db.Office_Office on u.OfficeID equals o.OfficeID
                                 join r in db.DayOffs on u.RDID equals r.RDID
                                 join s in db.OfficeSections on u.SectionID equals s.SectionID

                                 where p.AppEntityID == appEntityID
                                 select new PersonBasic
                                 {
                                     AppEntityID = p.AppEntityID,
                                     First = p.FirstName,
                                     Last = p.LastName,
                                     Badge = u.Badge,
                                     PIN = u.PIN,
                                     SAP = u.SAP,
                                     JobTitle = jt.Name,
                                     RankCode = jt.NameCode,
                                     RDs = r.Name,
                                     OfficeName = o.Name,
                                     SectionName = s.Name ?? "Unk",
                                     PicURL = (from pi in db.vPictures
                                               where pi.AppEntityID == p.AppEntityID
                                               orderby pi.DateTimeStamp descending
                                               select pi.ImagePath).FirstOrDefault(),
                                     Emails = (from ep in db.People
                                               join e in db.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                               join et in db.p_EmailAddressType on e.EmailAddressTypeID equals et.EmailAddressTypeID
                                               where ep.AppEntityID == appEntityID
                                               select new Email
                                               {
                                                   AddressType = et.Name,
                                                   userEmailAddress = e.EmailAddress
                                               }),
                                 });

            return myPersonBasic.ToList();
        }
    }
}