﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class OfficeAssigment
    {
        public int OfficeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Office { get; set; }
        public string OfficeCode { get; set; }

        //public int EnteredBy { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
       
    }
}