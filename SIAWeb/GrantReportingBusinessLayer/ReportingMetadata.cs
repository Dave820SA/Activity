using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GrantReportingBusinessLayer
{

    [MetadataType(typeof(ActivityCategory.Metadata))]
    public partial class ActivityCategory
    {
        sealed class Metadata
        {
            [Key]
            public int ActivityID { get; set; }

            [Required]
            [Display(Name= "Activity Category")]
            public string Name { get; set; }

            //[Required]
            //[Display(Name = "Bureau")]
            //public int BureauID { get; set; }

            //[Display(Name = "Last Update")]
            //public DateTime ModifiedDate { get; set; }

        }
    }

    [MetadataType(typeof(DailyActivity.Metadata))]
    public partial class DailyActivity
    {
        sealed class Metadata
        {
            [Key]
            public int AdminActivityID { get; set; }

            [Required]
            [Display(Name= "User ID")]
            public string AppEntityID { get; set; }

            [Required]
            public string Notes { get; set; }

            [Required]
            [Display(Name = "Start")]
            [DisplayFormat(DataFormatString = "{0:MM/dd HH:mm}")]
            public string ActivityStart { get; set; }

            [Required]
            [Display(Name = "End")]
            [DisplayFormat(DataFormatString = "{0:MM/dd HH:mm}")]
            public string ActivityEnd { get; set; }

            [Display(Name = "Approved")]
            public string ApprovedFlag { get; set; }

            [Display(Name = "More Info")]
            public string MoreInformationFlag { get; set; }
        }
    }



}
