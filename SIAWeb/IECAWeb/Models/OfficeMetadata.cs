using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IECAWeb.Models
{
    [MetadataType(typeof(Office_Office.Metadata))]
    public partial class Office_Office
    {
        sealed class Metadata
        {
            

            [Display(Name = "Office")]
            public string Name { get; set; }

            [Display(Name = "Office Code")]
            public string Code { get; set; }

        }
    }
}