using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SOPWeb.Models
{
    public class SOPCurrent
    {
        public int ID { get; set; }
        public int BureauId { get; set; }
        public string Bureau { get; set; }
        public string SOP { get; set; }
        [Display(Name = "SOP Info")]
        public string  SOPInfo { get; set; }
        [Display(Name = "Effective Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public string DocPath { get; set; }
    }
}