using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public string ItemDescription { get; set; }
        public string Status { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public string ItemType { get; set; }
    }
}