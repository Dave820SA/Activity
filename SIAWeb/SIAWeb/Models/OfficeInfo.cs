using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SIAWeb.Models
{
    public class OfficeInfo
    {
        public int OfficeID { get; set; }
        public int DivisionID { get; set; }
        [DisplayName("Office")]
        public string Name { get; set; }
        [DisplayName("Office Code")]
        public string Code { get; set; }
        public int PAOfficeID { get; set; }
    }
}