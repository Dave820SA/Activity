using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOPBusinessLayer;
using SOPWeb.Models;

namespace SOPWeb.Common
{
    public class SOPManager
    {
        SAPDActivityEntities db = new SAPDActivityEntities();

        public List<SOPCurrent> GetCurrentSOP()
        {
            return (from dh in db.DocHistories
                    join s in db.SOPs on dh.SOPID equals s.SOPID
                    join b in db.Office_Bureau on s.BureauID equals b.BureauID
                    where dh.EndDate == null
                    select new SOPCurrent
                    {
                        ID = dh.DocHistoryID,
                        BureauId = b.BureauID,
                        Bureau = b.Name,
                        SOP = s.Name,
                        SOPInfo = dh.DocInfo,
                        StartDate = dh.StartDate,
                        DocPath = dh.DocPath

                    }).ToList();
        }

    }
}