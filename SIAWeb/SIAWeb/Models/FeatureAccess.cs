using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class FeatureAccess
    {
        public int AppEnityID { get; set; }
        public int WebLinkID { get; set; }
        public int AppFeatureID { get; set; }
        public Boolean AllowFeatureFlag { get; set; }
        public string UnlockQ { get; set; }
        public DateTime UnlockAttempt { get; set; }
        public int UnlockedBy { get; set; }
        public DateTime UnlockDate { get; set; }
    }
}