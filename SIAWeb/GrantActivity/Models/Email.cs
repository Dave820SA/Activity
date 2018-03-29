using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrantActivity.Models
{
    public class EmployeeEmail
    {
        public int EmailAddresID { get; set; }
        public int AppEntityID { get; set; }
        public int AddressTypeID { get; set; }
        public string EmailAddress { get; set; }
    }
}