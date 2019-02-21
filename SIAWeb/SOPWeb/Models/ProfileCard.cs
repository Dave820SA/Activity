using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SOPWeb.Models
{
    public class ProfileCrad
    {
        public int AppEntityID { get; set; }
        public int GroupMemberID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        [DisplayName("Status")]
        public string WorkStatus { get; set; }
        public int? WSRanking { get; set; }
        public string Badge { get; set; }
        public int OfficeID { get; set; }
        [DisplayName("Office Code")]
        public string OfficeCode { get; set; }
        [DisplayName("Office Name")]
        public string OfficeName { get; set; }
        [DisplayName("Title")]
        public string JobTitle { get; set; }
        public string RankCode { get; set; }
        public int jtRanking { get; set; }
        [DisplayName("Day Off")]
        public string RD { get; set; }
        public string Shift { get; set; }
        public string MemberInfo { get; set; }
        public string PicURL { get; set; }
        public IEnumerable<EmailAddress> Email { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
    }
}