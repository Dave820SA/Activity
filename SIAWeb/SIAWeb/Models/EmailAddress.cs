﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class EmailAddress
    {
        public int EmailAddressTypeID { get; set; }
        public string AddressType { get; set; }
        public string userEmailAddress { get; set; }
    }
}