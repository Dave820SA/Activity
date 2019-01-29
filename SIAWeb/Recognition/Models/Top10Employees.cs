using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recognition.Models
{
    public class Top10Employee
    {
        public int AppEntityID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AwardCount { get; set; }
    }

    //public class Top10Employees
    //{
    //    public List<Top10Employee> SAPDTopAwards { get; set; }
    //}
}