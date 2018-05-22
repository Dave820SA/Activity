using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class PhoneNumber
    {
        public int PhoneTypeID { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNbr { get; set; }
    }
}