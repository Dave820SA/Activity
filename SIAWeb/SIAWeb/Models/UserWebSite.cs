using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class UserWebSite
    {
        public int WebSiteUserID { get; set; }
        public int WebLinkID { get; set; }
        public int AppEntityID { get; set; }
        public int EnteredByID { get; set; }
        public string WebSite { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}