using System.ComponentModel;

namespace IECAWeb.Models
{
    public class AssignedOfficers
    {
        public int AppEntityID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        public string Badge { get; set; }
        public int OfficeID { get; set; }
        [DisplayName("Office Code")]
        public string OfficeCode { get; set; }
        [DisplayName("Office Name")]
        public string Office { get; set; }
        [DisplayName("Title")]
        public string JobTitle { get; set; }
        public int jtRanking { get; set; }
        public string RankCode { get; set; }
        [DisplayName("Work Status")]
        public string Status { get; set; }
        public int WorkStatusCode { get; set; }
        public string WSNameCode { get; set; }
    }
}