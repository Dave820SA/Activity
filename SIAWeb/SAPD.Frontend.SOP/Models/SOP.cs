using System;
using System.ComponentModel.DataAnnotations;

namespace SAPD.Frontend.SOP.Models
{
    public class SOPs
    {
        //public int ID { get; set; }
        //public int BureauId { get; set; }
        //public string Bureau { get; set; }
        //public string SOP { get; set; }
        //[Display(Name = "SOP Info")]
        //public string SOPInfo { get; set; }
        //[Display(Name = "Effective Date")]
        //public DateTime StartDate { get; set; }
        //[Display(Name = "End Date")]
        //public DateTime? EndDate { get; set; }
        //public string DocPath { get; set; }

        public int SOPId { get; set; }
        public string Name { get; set; }
        public int BureauId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string ExtraValue { get; set; }
    }
}