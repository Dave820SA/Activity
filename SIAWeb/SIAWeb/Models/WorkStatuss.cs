using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class WorkStatuss
    {   
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StatusInfo { get; set; }
        public string WorkStatus { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}