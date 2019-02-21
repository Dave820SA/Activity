using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOPWeb.Models;
using PersonnelBusinessLayer;


namespace SOPWeb.Common
{
    public class PersonManager
    {
        PersonnelContext db = new PersonnelContext();

        public List<ProfileCrad> GetAdminMember()
        {
            return (from p in db.People
                        join wu in db.WebSiteUsers on p.AppEntityID equals wu.AppEntityID
                        where wu.SIA_WebLinks.WebLinkID == 13 && wu.WebSiteRoleID == 2
                        select new ProfileCrad
                        {
                            AppEntityID = p.AppEntityID,
                            First = p.FirstName,
                            Last = p.LastName,
                            Badge = p.User_User.Badge,
                            SAP = p.User_User.SAP,
                            RD = p.User_User.User_DayOff.Name,
                            Shift = p.User_User.User_Shift.Name,
                            OfficeID = p.User_User.Office_Office.OfficeID,
                            OfficeCode = p.User_User.Office_Office.Code,
                            OfficeName = p.User_User.Office_Office.Name,
                            WorkStatus = p.User_User.User_WorkStatus.Name,
                            JobTitle = p.User_User.User_JobTitle.Name,
                            RankCode = p.User_User.User_JobTitle.NameCode,
                            PicURL = (from pi in db.vPictures
                                      where pi.AppEntityID == p.AppEntityID
                                      orderby pi.DateTimeStamp descending
                                      select pi.ImagePath).FirstOrDefault(),

                            Email = (from ep in db.People
                                      join e in db.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                      join et in db.p_EmailAddressType on e.EmailAddressTypeID equals et.EmailAddressTypeID
                                      where ep.AppEntityID == p.AppEntityID && e.EmailAddressTypeID == 1
                                      select new EmailAddress
                                      {
                                          AddressType = et.Name,
                                          userEmailAddress = e.EmailAddress
                                      }),
                            PhoneNumbers = (from pp in db.People
                                            join ph in db.PersonPhones on pp.AppEntityID equals ph.AppEntityID
                                            join phType in db.PhoneNumberTypes on ph.PhoneNumberTypeID equals phType.PhoneNumberTypeID
                                            where ph.AppEntityID == p.AppEntityID && (phType.PhoneNumberTypeID == 1 || phType.PhoneNumberTypeID == 2)
                                            select new PhoneNumber
                                            {
                                                PhoneType = phType.Name,
                                                PhoneNbr = ph.PhoneNumber
                                            }),

                        }).ToList();

        }

    }
}