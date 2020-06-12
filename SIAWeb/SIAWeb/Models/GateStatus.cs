using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWeb.Models;
using UserBusinessLayer;

namespace SIAWeb.Models
{
    public class GateStatus
    {
        UserLayerEntities db = new UserLayerEntities();

        //public List<GateItems> GetGateStatus(int appUser)
        //{
        //    var gInfo = (from g in db.spGateInfo(appUser)
        //                 select new GateItems
        //                 {
        //                     Status = g.GateStatus.HasValue ? g.GateStatus.Value : false,
        //                     QuestionNbrs = g.GateQuestion,
        //                     Attempt = g.GateAttemptDate.HasValue ? g.GateAttemptDate.Value : DateTime.Now
        //                 });


        //    return gInfo.ToList();

        //}
    }
}