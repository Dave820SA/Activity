﻿using System.ComponentModel;

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
        public string AddressType { get; set; }
        public string AdressL1 { get; set; }
        public string AddressL2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

    }
}