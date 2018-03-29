using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrantActivity.Models
{
    public class Daily
    {
        public int AdminDailyID { get; set; }
        public int AppEntity { get; set; }
        public int GrantTypeID { get; set; }
        public DateTime DailyStart { get; set; }
        public DateTime DailyEnd { get; set; }
        public DateTime EnteredDate { get; set; }
        public bool ApproveFlag { get; set; }
        public bool MoreInfoFlag { get; set; }
        public string AdminNotes { get; set; }
        public int ApproveByID { get; set; }
        public DateTime ApproveDate { get; set; }
        //public string wEmail { get; set; }

        public IEnumerable<Activity> Activities { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<EmployeeEmail> Emails { get; set; }

    }
}