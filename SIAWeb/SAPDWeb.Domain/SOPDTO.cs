using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPDWeb.Domain
{
    public class SOPDTO
    {
        public int ID { get; set; }
        public int BureauId { get; set; }
        public string Bureau { get; set; }
        public string SOP { get; set; }
        //[Display(Name = "SOP Info")]
        public string SOPInfo { get; set; }
        //[Display(Name = "Effective Date")]
        public DateTime StartDate { get; set; }
        //[Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public string DocPath { get; set; }
    }
}
