using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPDWeb.Domain
{
    public class SOPDomainModel
    {

        public int SOPId { get; set; }
        public string Name { get; set; }
        public int BureauId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int ExtraValue { get; set; }
    }
}
