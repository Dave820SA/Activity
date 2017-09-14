using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RecognitionBusinessLayer
{
    [MetadataType(typeof(Recognize.Metadata))]
    public partial class Recognize
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int RecognitionId { get; set; }

            [Required]
            [Display(Name = "Type")]
            public int RecogTypeId { get; set; }


            [Display(Name = "Award")]
            public int AwardTypeId { get; set; }

            [Required]
            [Display(Name = "Employee")]
            public int AppEntityID { get; set; }

            [Required]
            [Display(Name = "Office")]
            public int OfficeId { get; set; }

            [Display(Name = "Document")]
            public int DocPath { get; set; }

            [Display(Name = "Date Issued")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime IssuedDate { get; set; }

        }
    }

    [MetadataType(typeof(Person.Metadata))]
    public partial class Person
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int AppEntityID { get; set; }

           
            [Display(Name = "First")]
            public string FirstName { get; set; }


            [Display(Name = "Last")]
            public string LastName { get; set; }

            
            [Display(Name = "Badge")]
            public string Badge { get; set; }

            
            [Display(Name = "Office")]
            public string Office { get; set; }

            [Display(Name = "Employee")]
            public string FullName { get; set; }

        }
    }


    [MetadataType(typeof(AwardType.Metadata))]
    public partial class AwardType
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int AwardTypeId { get; set; }


            [Display(Name = "Award")]
            public string Name { get; set; }


            [Display(Name = "Award Code")]
            public string Code { get; set; }

        }
    }

    [MetadataType(typeof(RecognitionType.Metadata))]
    public partial class RecognitionType
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int RecognitionTypeId { get; set; }


            [Display(Name = "Recognition Type")]
            public string Name { get; set; }


            [Display(Name = "Recognition Code")]
            public string Code { get; set; }

        }
    }


    [MetadataType(typeof(Office.Metadata))]
    public partial class Office
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int OfficeID { get; set; }


            [Display(Name = "Office")]
            public string Name { get; set; }


            [Display(Name = "Office Code")]
            public string Code { get; set; }

        }
    }

    [MetadataType(typeof(Award_spRecTypeMonthYear_Result.Metadata))]
    public partial class Award_spRecTypeMonthYear_Result
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int RecognitionId { get; set; }

            
            [Display(Name = "Employee")]
            public string FullName { get; set; }


            [Display(Name = "Date Issued")]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime IssuedDate { get; set; }

        }
    }
}