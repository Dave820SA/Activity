using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IECAWeb.Models
{
    public class Audit
    {
        public int IECAID { get; set; }
        public int AppEntity { get; set; }
        public int OfficeID { get; set; }
        public bool? CaseAuditFlag { get; set; }
        public DateTime? AuditDate { get; set; }
        public DateTime? InserDate { get; set; }
    }
}