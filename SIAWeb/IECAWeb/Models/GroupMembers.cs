using System.Collections.Generic;
using System.ComponentModel;

namespace IECAWeb.Models
{
    public class GroupMembers
    {
        public int GroupTitleID { get; set; }
        public int GroupMemberID { get; set; }
        public string GroupName { get; set; }
        public int AppEntityID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string SAP { get; set; }
        public string Badge { get; set; }
        public int WorkStatusRank { get; set; }
        public string WorkStatus { get; set; }
        public int OfficeID { get; set; }
        public string GroupInfo { get; set; }
        public string MemberInfo { get; set; }
        public string OfficeCode { get; set; }
        public string Office { get; set; }
        [DisplayName("Title")]
        public string JobTitle { get; set; }
        public string RankCode { get; set; }
        public string PicURL { get; set; }
        public bool Visible { get; set; }
        public IEnumerable<EmailAddress> Emails { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

    }

    public class EmailAddress
    {
        public int EmailAddressTypeID { get; set; }
        public string AddressType { get; set; }
        public string userEmailAddress { get; set; }
    }

    public class PhoneNumber
    {
        public int PhoneTypeID { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNbr { get; set; }
    }

}