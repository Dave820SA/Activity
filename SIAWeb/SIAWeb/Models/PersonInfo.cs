using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace SIAWeb.Models
{
    public class PersonInfo
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
        [DisplayName("Day Off")]
        public string RD { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Employeed { get; set; }
        public string Email { get; set; }

        public IEnumerable<Badge> Badges { get; set; }
        public IEnumerable<RD> RDs { get; set; }
        public IEnumerable<EmailAddress> Emails { get; set; }
       
        //public List<RDs> RDHist { get; set; }
        
        //public List<WorkStatuss> StatusHist { get; set; }
        
        //public List<Shifts> ShiftHist { get; set; }
    }
}