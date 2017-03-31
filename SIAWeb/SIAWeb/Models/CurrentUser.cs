using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class CurrentUser
    {
        public int AppEntityID { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        public string UserName { get; set; }
        public string DutyStatus { get; set; }
        public string OfficeCode { get; set; }
    }
}