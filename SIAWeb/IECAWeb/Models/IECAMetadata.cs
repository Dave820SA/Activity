using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IECAWeb.Models
{
    [MetadataType(typeof(AuditHistrory.Metadata))]
    public partial class AuditHistrory
    {
        sealed class Metadata
        {
            [Key]
            public int IECAID { get; set; }

            [Required]
            [Display(Name = "Officer ID")]
            public int AppEntityID { get; set; }

            [Required]
            [Display(Name = "Office ID")]
            public int OfficeID { get; set; }

            [Display(Name = "Case Flag")]
            public bool CaseAuditFlag { get; set; }

            [Display(Name = "Audit Notes")]
            public string AuditNotes { get; set; }

            [Display(Name = "Audit Date")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm}")]
            public DateTime AuditDate { get; set; }

            [Display(Name = "Insert Date")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm}")]
            public DateTime InsertDate { get; set; }

        }
    }

    [MetadataType(typeof(Auditor.Metadata))]
    public partial class Auditor
    {
        sealed class Metadata
        {
            [Key]
            public int AppEntityID { get; set; }

            
            [Display(Name = "Auditor")]
            public string ApproveBy { get; set; }

        }
    }

}