using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonnelBusinessLayer;
using IECAWeb.Models;

namespace IECAWeb.Common
{
    public class GetAssigned
    {
        PersonBasicContex pc = new PersonBasicContex();

        public List<AssignedOfficers> GetAssignedOfficers(int officeID)
        {
            var myAssigned = (from p in pc.Person_Person
                              join u in pc.User_User on p.AppEntityID equals u.AppEntityID
                              join ws in pc.User_WorkStatus on u.WorkStatusID equals ws.WorkStatusID
                              join jt in pc.User_JobTitle on u.JobTitleID equals jt.JobTitleID
                              where u.OfficeID == officeID && ws.Ranking <= 9
                              select new AssignedOfficers
                              {
                                  AppEntityID = p.AppEntityID,
                                  First = p.FirstName,
                                  Last = p.LastName,
                                  JobTitle = jt.Name,
                                  jtRanking = (jt.jtRanking ?? 12),
                                  RankCode = jt.NameCode,
                                  Status = ws.Name,
                                  WSNameCode = ws.NameCode

                              });



            return myAssigned.ToList();
        }
    }
}