using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SIAWeb.Models
{
    public class OfficeInfo
    { 
        public string Bureau { get; set; }
        public string Division { get; set; }
        public string DivisionSection { get; set; }
        public int OfficeID { get; set; }
        [DisplayName("Office")]
        public string Name { get; set; }
        [DisplayName("Office Code")]
        public string Code { get; set; }
        public int PAOfficeID { get; set; }

        public IEnumerable<People> PeopleAssigned { get; set; }
       
    }
}