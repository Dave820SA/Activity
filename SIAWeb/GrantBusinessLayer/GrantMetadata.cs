using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GrantBusinessLayer
{
   
        [MetadataType(typeof(Grant_Activity.Metadata))]
        public partial class Grant_Activity
        {
            sealed class Metadata
            {
                [Key]
                public int ActivityID { get; set; }

                [Required]
                [Display(Name = "Daily")]
                public int DailyID { get; set; }

                [Required]
                [Display(Name = "Category")]
                public int CategoryID { get; set; }

                [Display(Name = "Activity Note")]
                public String Notes { get; set; }

                [Display(Name = "Date Entered")]
                [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
                public DateTime EnteredDate { get; set; }

            }
        }


        [MetadataType(typeof(Grant_Category.Metadata))]
        public partial class Grant_Category
        {
            sealed class Metadata
            {
                [Key]
                public int CategoryID { get; set; }

                [Required]
                [Display(Name = "Activity Category")]
                public String Name { get; set; }
            }
        }


        [MetadataType(typeof(Grant_Daily.Metadata))]
        public partial class Grant_Daily
        {
            sealed class Metadata
            {
                [Key]
                public int AdminDailyID { get; set; }

                [Required]
                [Display(Name = "User")]
                public int AppEntityID { get; set; }

                [Required]
                [Display(Name = "Type Activity")]
                public int GrantTypeID { get; set; }

                [Required]
                [Display(Name = "Start")]
                [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
                public DateTime DailyStart { get; set; }

                [Required]
                [Display(Name = "End")]
                [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
                public DateTime DailyEnd{ get; set; }

                [Display(Name = "Date Entered")]
                [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
                public DateTime EnteredDate { get; set; }

                [Display(Name = "Approve")]
                public Boolean ApprovedFlag { get; set; }

                [Display(Name = "More Info")]
                public Boolean MoreInformationFlag { get; set; }

                [Display(Name = "Admin Notes")]
                public String AdminNotes { get; set; }

                [Display(Name = "Approved By")]
                public int ApprovedByID { get; set; }

                [Display(Name = "Date Approved")]
                [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
                public DateTime ApprovedDate { get; set; }


            }
        }

        [MetadataType(typeof(Grant_GrantType.Metadata))]
        public partial class Grant_GrantType
        {
            sealed class Metadata
            {
                [Key]
                public int GrantTypeID { get; set; }

                [Required]
                [Display(Name = "Grant Type")]
                public String GrantType { get; set; }
            }
        }


    
}
