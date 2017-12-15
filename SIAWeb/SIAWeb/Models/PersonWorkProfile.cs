using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SIAWeb.Models
{
    public class PersonWorkProfile
    {
        public int AppEntityID { get; set; }
        public string SAP { get; set; }
        public int OfficeID { get; set; }
        [DisplayName("Office Code")]
        public string OfficeCode { get; set; }
        [DisplayName("Office Name")]
        public string Office { get; set; }
        [DisplayName("Work Status")]
        public string Status { get; set; }
        [DisplayName("Day Off")]
        public string RD { get; set; }
        public string Shift { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Employeed { get; set; }

        public IEnumerable<EmailAddress> Emails { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public IEnumerable<Badge> Badges { get; set; }
        public IEnumerable<RD> RDs { get; set; }
        public IEnumerable<OfficeAssigment> OfficeAssigments { get; set; }
        public IEnumerable<UserAward> myAwards { get; set; }
    }
}