using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class UserAward
    {
        //public int AppEntity { get; set; }
        public string DocPath { get; set; }
        public String AwardName{ get; set; }
        public DateTime IssuedDate { get; set; }
    }
}