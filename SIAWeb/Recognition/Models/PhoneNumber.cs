using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Recognition.Models
{
    public class PhoneNumber
    {
        public int PhoneID { get; set; }
        public int AppEntityID { get; set; }
        //[Required(ErrorMessage = "You must provide a phone number")]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNbr { get; set; }
        public int PhoneTypeID { get; set; }
        public string PhoneType { get; set; }


    }
}