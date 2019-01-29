using System.ComponentModel.DataAnnotations;

namespace Recognition.Models
{
    public class EmailAddress
    {
        public int AppEntityID { get; set; }
        public int EmailAddressTypeID { get; set; }
        public string AddressType { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not Valid")]
        public string userEmailAddress { get; set; }
    }
}