using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPDWeb.Domain
{
   public class DocHistoryDomainModel
    {
        public int DocHistoryId { get; set; }
        public int SOPId { get; set; }
        public string DocInfo { get; set; }
        public string DocPath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
