using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
	

namespace SIAWebLinksBusinessLayer
{
    [MetadataType(typeof(WebCategories.Metadata))]
    public partial class WebCategories
    {
       sealed class Metadata
        {
            [Key]
            public int WebCategoriesID { get; set; }
            [Required]
            [Display(Name="Web Category")]
            public string Name { get; set; }
        }
    }

    [MetadataType(typeof(WebLinks.Metadata))]
    public partial class WebLinks
    {
        sealed class Metadata
        {
            [Key]
            public int WebLinkID { get; set; }

            [Required]
            [Display(Name = "Web Category")]
            public string WebCategoryID { get; set; }

            [Required]
            [Display(Name = "Web Name")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Web Address")]
            public string WebLink { get; set; }

            [Display(Name= "Visaible")]
            public Boolean VisibleFlag { get; set; }
        }
    }
}
