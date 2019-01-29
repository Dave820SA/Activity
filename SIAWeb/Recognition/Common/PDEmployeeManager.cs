using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonnelBusinessLayer;
using Recognition.Models;

namespace Recognition.Common
{
    public class PDEmployeeManager
    {
        PersonnelContext db = new PersonnelContext();

        public List<Top10Employee> TopEmployees()
        {
            //Create a list of active employees and count the number of awards
            var topEmp = (from a in db.Awards
                          join u in db.Users on a.AppEntityID equals u.AppEntityID
                          where u.WorkStatusID <= 9
                          group a by a.AppEntityID
                          into TotalAwards
                          select new Top10Employee
                          {
                              AppEntityID = TotalAwards.Key,
                              FirstName = null,
                              LastName = null,
                              AwardCount = TotalAwards.Count()

                          });

            //Use topEmp list from above and create a list of the to 10 recipents
            var lstEmp = (from a in topEmp
                          join u in db.Users on a.AppEntityID equals u.AppEntityID
                          join p in db.People on u.AppEntityID equals p.AppEntityID
                          select new Top10Employee
                          {
                              AppEntityID = u.AppEntityID,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              AwardCount = a.AwardCount
                          }).OrderByDescending(x => x.AwardCount).Take(10);


            return lstEmp.ToList();
           
        }

        public List<PDEmployee> Last15Entered()
        {
            //return the last 15 employees that recieved awards
            var lstEnter = (from a in db.Awards
                            join p in db.People on a.AppEntityID equals p.AppEntityID
                            select new PDEmployee
                            {
                                AppEntityID = a.AppEntityID,
                                First = p.FirstName,
                                Last = p.LastName,
                                LastUpdate = a.IssuedDate
                            }).OrderByDescending(x => x.LastUpdate).Take(15);

            return lstEnter.ToList();
        }

        public List<PDEmployee> ListOfEmployees()
        {
            //return all employees in the person table
            var loe = (from p in db.People
                       join u in db.Users on p.AppEntityID equals u.AppEntityID
                       join o in db.Office_Office on u.OfficeID equals o.OfficeID
                       select new PDEmployee
                       {
                           AppEntityID = p.AppEntityID,
                           First = p.FirstName,
                           Last = p.LastName,
                           Badge = u.Badge,
                           OfficeCode = o.Code
                       }).OrderBy(x => x.Last);

            return loe.ToList();
        }

        public List<ProfileCrad> GetAppAdmins()
        {
            var gaa = (from p in db.People
                       join u in db.Users on p.AppEntityID equals u.AppEntityID
                       join jt in db.JobTitles on u.JobTitleID equals jt.JobTitleID
                       join o in db.Office_Office on u.OfficeID equals o.OfficeID
                       join ws in db.WorkStatus on u.WorkStatusID equals ws.WorkStatusID
                       join wsu in db.WebSiteUsers on u.AppEntityID equals wsu.AppEntityID
                       where ws.Ranking <= 9 && wsu.WebLinkID == 60 && wsu.WebSiteRoleID == 1
                       select new ProfileCrad
                       {
                           AppEntityID = p.AppEntityID,
                           First = p.FirstName,
                           Last = p.LastName,
                           Badge = u.Badge,
                           SAP = u.SAP,
                           RD = u.User_DayOff.Name,
                           Shift = u.User_Shift.Name,
                           OfficeName = o.Name,
                           OfficeCode = o.Code,
                           RankCode = jt.NameCode,
                           PicURL = (from pi in db.vPictures
                                     where pi.AppEntityID == p.AppEntityID
                                     orderby pi.DateTimeStamp descending
                                     select pi.ImagePath).FirstOrDefault(),
                           Emails = (from ep in db.People
                                     join e in db.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                     join et in db.AddressTypes on e.EmailAddressTypeID equals et.AddressTypeID
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

                       });

            return gaa.ToList();
                       
        }

        public List<ProfileCrad> GetAppAdmins(int Id)
        {
            var gaa = (from p in db.People
                       join u in db.Users on p.AppEntityID equals u.AppEntityID
                       join jt in db.JobTitles on u.JobTitleID equals jt.JobTitleID
                       join o in db.Office_Office on u.OfficeID equals o.OfficeID
                       join ws in db.WorkStatus on u.WorkStatusID equals ws.WorkStatusID
                       join wsu in db.WebSiteUsers on u.AppEntityID equals wsu.AppEntityID
                       where ws.Ranking <= 9 && wsu.WebLinkID == 60 && u.AppEntityID == Id
                       select new ProfileCrad
                       {
                           AppEntityID = p.AppEntityID,
                           First = p.FirstName,
                           Last = p.LastName,
                           Badge = u.Badge,
                           SAP = u.SAP,
                           RD = u.User_DayOff.Name,

                           Shift = u.User_Shift.Name,
                           OfficeName = o.Name,
                           OfficeCode = o.Code,
                           RankCode = jt.NameCode,
                           PicURL = (from pi in db.vPictures
                                     where pi.AppEntityID == p.AppEntityID
                                     orderby pi.DateTimeStamp descending
                                     select pi.ImagePath).FirstOrDefault(),
                           Emails = (from ep in db.People
                                     join e in db.P_EmailAddress on ep.AppEntityID equals e.AppEntityID
                                     join et in db.AddressTypes on e.EmailAddressTypeID equals et.AddressTypeID
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

                       });

            return gaa.ToList();

        }

        
    }
}