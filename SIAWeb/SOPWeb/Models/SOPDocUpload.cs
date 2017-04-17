using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SOPWeb.Models
{
    public class SOPDocUpload
    {
        //[Key]
        //public int DocHistoryID { get; set; }
        //[Required]
        //public int SOPID { get; set; }
        //[Required]
        //[DataType(DataType.ImageUrl)]
        public string DocPath { get; set; }
        //public string DocInfo { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        
       
    }
}