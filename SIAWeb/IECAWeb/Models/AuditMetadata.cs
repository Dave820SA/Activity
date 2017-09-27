using System;
using System.ComponentModel.DataAnnotations;

namespace IECAWeb.Models
{
    [MetadataType(typeof(Officer.Metadata))]
    public partial class Officer
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int AppEntityID { get; set; }


            [Display(Name = "First")]
            public string First { get; set; }


            [Display(Name = "Last")]
            public string Last { get; set; }


            [Display(Name = "Badge")]
            public string Badge { get; set; }

            [Display(Name = "Rank")]
            public string RankLong { get; set; }

            [Display(Name = "RankCode")]
            public string Rank { get; set; }

            [Display(Name = "Office")]
            public string OfficeLong { get; set; }

            [Display(Name = "OfficeCode")]
            public string OfficeShort { get; set; }

        }
    }
}