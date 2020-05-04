using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPD.Frontend.SOP.Models
{
    public class SOPModel
    {
        public int SOPId { get; set; }
        public string Name { get; set; }
        public int BureauId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string ExtraValue { get; set; }
    }
}