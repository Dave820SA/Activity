using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PersonnelBusinessLayer
{
    [MetadataType(typeof(GroupTitle.Metadata))]
    public partial class GroupTitle
    {
        sealed class Metadata
        {
            [Key]
            [Display(Name = "ID")]
            public int GroupTitleID { get; set; }

            [Required]
            [Display(Name = "Group Name")]
            public string Name { get; set; }


            [Display(Name = "Group Info")]
            public string GroupInfo { get; set; }


            [Display(Name = "List Rank")]
            public int gtRanking { get; set; }

            [Required]
            [Display(Name = "Visible")]
            public bool VisibleFlag { get; set; }

        }
    }

}
