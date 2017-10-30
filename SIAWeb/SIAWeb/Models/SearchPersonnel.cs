using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class SearchFor
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string Badge { get; set; }
        public int OfficeID { get; set; }
        public string OfficeCode { get; set; }
        public string Office { get; set; }
    }
}