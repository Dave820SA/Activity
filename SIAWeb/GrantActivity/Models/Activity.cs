using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrantActivity.Models
{
    public class Activity
    {
        //public int ActivityID { get; set; }
        public int DailyID { get; set; }
        public int CategoryID { get; set; }
        public string Notes { get; set; }
        public DateTime EnteredDate { get; set; }
    }
}