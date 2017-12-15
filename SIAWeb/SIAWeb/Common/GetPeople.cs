using System.Collections.Generic;
using System.Linq;
using SIAWeb.Models;
using PersonnelBusinessLayer;


namespace SIAWeb.Common
{
    public class GetPeople
    {
        PersonnelContext db = new PersonnelContext();

        public List<People> GetSearched(string searchString)
        {
            var myPeople = from p in db.spPersonnelSearch(searchString)
                           select new People
                           {
                               AppEntityID = p.AppEntityID,
                               First = p.FirstName,
                               Last = p.LastName,
                               SAP = p.SAP,
                               Badge = p.Badge,
                               Office = p.Office,
                               OfficeCode = p.OfficeCode,
                               RankCode = p.RankCode,
                               jtRanking = (p.Ranking ?? 12),
                               Status = p.WorkStatus

                           };
                                 
            return myPeople.ToList();

        }


    }
}