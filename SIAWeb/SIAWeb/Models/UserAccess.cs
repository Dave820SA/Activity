using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace SIAWeb.Models
{
    public class UserAccess 
    {
        public int AppEntityID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        public string Badge { get; set; }

        public IEnumerable<UserWebSite> UserWebSites { get; set; }
        public IEnumerable<FeatureAccess> WebSiteFeatures { get; set; }
    }
}