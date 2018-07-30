using System.ComponentModel;

namespace IECAWeb.Models
{
    public class PersonBasic
    {
        public int AppEntityID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string PIN { get; set; }
        public string SAP { get; set; }
        public string Badge { get; set; }
        [DisplayName("Title")]
        public string JobTitle { get; set; }
        public string RankCode { get; set; }
        public string PicURL { get; set; }
    }
}