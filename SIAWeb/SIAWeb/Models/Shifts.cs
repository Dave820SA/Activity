﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIAWeb.Models
{
    public class Shifts
    {
        public int EnteredBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Shift { get; set; }
    }
}