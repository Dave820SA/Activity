using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using OfficeBusinessLayer;

namespace SIAWeb.Common
{
    public class GetOffice
    {
        OfficeContex db = new OfficeContex();
        public List<OfficeInfo> GetOfficeInfo(int officeID)
        {
            var newOffice = (from b in db.Bureaux
                             join div in db.Divisions on b.BureauID equals div.BureauID

                             join divs in db.DivisionSections on div.DivisionID equals divs.DivisionID

                             join o in db.Offices on divs.DivisionSectionID equals o.DivisionSectionID

                             //join oh in db.OfficeHistories on o.OfficeID equals oh.OfficeID

                             where  o.OfficeID == officeID
                             select new OfficeInfo
                             {
                                 Bureau = b.Name,
                                 Division = div.Name,
                                 DivisionSection = divs.Name,
                                 Name = o.Name,
                                 Code = o.Code,
                                 OfficeID = o.OfficeID,

                                  PeopleAssigned = (from ohst in db.OfficeHistories
                                                    join u in db.Users on ohst.AppEntityID equals u.AppEntityID
                                                    join p in db.People on u.AppEntityID equals p.AppEntityID
                                                    join bnbr in db.BadgeHistories on u.AppEntityID equals bnbr.AppEntityID into nob
                                                    from nb in nob.DefaultIfEmpty()

                                                    join j in db.JobTitleHistories on u.AppEntityID equals j.AppEntityID into job
                                                    from jb in job.DefaultIfEmpty()

                                                    join jth in db.JobTitles on jb.JobTitleID equals jth.JobTitleID

                                                    join w in db.WorkStatusHistories on u.AppEntityID equals w.AppEntityID into wsh
                                                    from ws in wsh.DefaultIfEmpty()

                                                    join wst in db.WorkStatus on ws.WorkstatusID equals wst.WorkStatusID

                                                    where (ohst.EndDate == null && nb.EndDate == null && jb.EndDate == null && ws.EndDate == null) && wst.Ranking >= 9
                                                    select new People
                                                    {
                                                        AppEntityID = u.AppEntityID,
                                                        First = p.FirstName,
                                                        Last = p.LastName,
                                                        SAP = u.SAP,
                                                        Badge = nb.Badge,
                                                        JobTitle = jth.Name,
                                                        jtRanking = (jth.jtRanking ?? 12),
                                                        RankCode = jth.NameCode,
                                                        Status = wst.Name


                                                    }),
                                                   

                                 
                             });
                             
                            
                             
                          

             return newOffice.ToList();                 

        }
    }
}