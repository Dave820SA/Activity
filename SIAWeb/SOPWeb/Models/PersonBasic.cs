using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SOPWeb.Models
{
    public class PersonBasic
    {
        public int PA_UserID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        public string Badge { get; set; }
        [DisplayName("Title")]
        public string JobTitle { get; set; }
        public string RankCode { get; set; }
        public string RDs { get; set; }
        public string DutyHrs { get; set; }
        public string OfficeName { get; set; }
        public string OfficeCode { get; set; }
        public IEnumerable<EmailAddress> Emails { get; set; }
        public IEnumerable<PersonPicture> PicURL { get; set; }
    }
}