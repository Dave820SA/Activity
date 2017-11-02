using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class People
    {
        public int AppEntityID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        public string Badge { get; set; }
        public int OfficeID { get; set; }
        public string OfficeCode { get; set; }
        public string Office { get; set; }
        public string JobTitle { get; set; }
        public int jtRanking { get; set; }
        public string RankCode { get; set; }
        public string Status { get; set; }
    }
}