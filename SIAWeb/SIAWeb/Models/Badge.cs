using System;
using System.ComponentModel;

namespace SIAWeb.Models
{
    public class Badge
    {
        public int EnteredBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("From")]
        public DateTime StartDate { get; set; }
        [DisplayName("To")]
        public DateTime EndDate { get; set; }
        public string BadgeNbr { get; set; }
    }
}