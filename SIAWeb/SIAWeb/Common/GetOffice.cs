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
            var newOffice = (from o in db.Offices
                             where o.OfficeID == officeID
                             select new OfficeInfo
                             {
                                 Name = o.Name,
                                 Code = o.Code,
                                 OfficeID = o.OfficeID
                             });

             return newOffice.ToList();                 

        }
    }
}