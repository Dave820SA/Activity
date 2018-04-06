using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using PersonnelBusinessLayer;

namespace SIAWeb.Common
{
    public class PersonBasicGet
    {
        //PersonBasicContex db = new PersonBasicContex();

        PersonnelContext db = new PersonnelContext();

        public List<PersonBasic> GetPersonBasicInfo(int appEntityID)
        {

            var myPersonBasic = (from p in db.People
                                 join u in db.Users on p.AppEntityID equals u.AppEntityID
                                 join jt in db.JobTitles on u.JobTitleID equals jt.JobTitleID
                                 
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
                                    PicURL = (from pi in db.vPictures
                                              where pi.AppEntityID == p.AppEntityID
                                              orderby pi.DateTimeStamp descending
                                              select pi.ImagePath).FirstOrDefault()
                                 });

            return myPersonBasic.ToList();

            //var myPersonBasic = (from p in db.Person_Person
            //                      join u in db.User_User on p.AppEntityID equals u.AppEntityID
            //                      join jt in db.User_JobTitle on u.JobTitleID equals jt.JobTitleID
            //                      where p.AppEntityID == appEntityID
            //                      select new PersonBasic
            //                      {
            //                          AppEntityID = p.AppEntityID,
            //                          First = p.FirstName,
            //                          Last = p.LastName,
            //                          Badge = u.Badge,
            //                          PIN = u.PIN,
            //                          SAP = u.SAP,
            //                          JobTitle = jt.Name,
            //                          RankCode = jt.NameCode
            //                      });

            //return myPersonBasic.ToList();


        }
    }
}