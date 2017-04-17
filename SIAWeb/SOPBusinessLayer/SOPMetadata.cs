using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SOPBusinessLayer
{
    [MetadataType(typeof(SOP.Metadata))]
    public partial class SOP
    {
        sealed class Metadata
        {
            [Key]
            public int SOPID { get; set; }

            [Required]
            [Display(Name="SOP")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Bureau")]
            public int BureauID { get; set; }

            [Display(Name = "Last Update")]
            public DateTime ModifiedDate { get; set; }
          
        }
    }

    [MetadataType(typeof(Bureau.Metadata))]
    public partial class Bureau
    {
        sealed class Metadata
        {
            [Key]
            public int BureauID { get; set; }

            [Required]
            [Display(Name = "Bureau")]
            public String Name { get; set; }

        }
    }

    [MetadataType(typeof(SOP_vCurrentDoc.Metadata))]
    public partial class SOP_vCurrentDoc
    {
        sealed class Metadata
        {
            [Key]
            public int ID { get; set; }

            //[Required]
            [Display(Name = "Bureau")]
            public String Bureau { get; set; }

            [Display(Name = "SOP")]
            public string SOP { get; set; }

            [Display(Name = "Efective On")]
            public DateTime StartDate { get; set; }

        }
    }

    [MetadataType(typeof(DocHistory.Metadata))]
    public partial class DocHistory
    {
        sealed class Metadata
        {
            [Key]
            public int DocHistoryID { get; set; }

            [Required]
            [Display(Name = "SOP")]
            public int SOPID { get; set; }

            [Display(Name = "SOP Info")]
            public string DocInfo { get; set; }

            [Required]
            [Display(Name = "Path")]
            public string DocPath { get; set; }

            [Required]
            [Display(Name = "Effect On")]
            public DateTime StartDate { get; set; }
            
        }
    }
}
