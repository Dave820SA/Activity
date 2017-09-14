﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recognition.Models
{
    public class MonthYearManager
    {
        public static List<MonthName> GetMonthNames()
        {
            return new List<MonthName>{
                new MonthName { MonthNbr =1, MoName = "January", MonthShortName = "Jan"},
                new MonthName { MonthNbr =2, MoName = "February", MonthShortName = "Feb"},
                new MonthName { MonthNbr =3, MoName = "March", MonthShortName = "Mar"},
                new MonthName { MonthNbr =4, MoName = "April", MonthShortName = "Apr"},
                new MonthName { MonthNbr =5, MoName = "May", MonthShortName = "May"},
                new MonthName { MonthNbr =6, MoName = "June", MonthShortName = "June"},
                new MonthName { MonthNbr =7, MoName = "July", MonthShortName = "Jul"},
                new MonthName { MonthNbr =8, MoName = "August", MonthShortName = "Aug"},
                new MonthName { MonthNbr =9, MoName = "September", MonthShortName = "Sep"},
                new MonthName { MonthNbr =10, MoName = "October", MonthShortName = "Oct"},
                new MonthName { MonthNbr =11, MoName = "November", MonthShortName = "Nov"},
                new MonthName { MonthNbr =12, MoName = "December", MonthShortName = "Dec"},
                };

        }

        public class MonthName
        {
            public int MonthNbr { get; set; }
            public string MoName { get; set; }
            public string MonthShortName { get; set; }
        }


        public static List<AwardYear> GetYearNames()
        {
            return new List<AwardYear>{
                new AwardYear { YearNbr = 2015, YearName = "2015", YearShortName = "15"},
                new AwardYear { YearNbr = 2016, YearName = "2016", YearShortName = "16"},
                new AwardYear { YearNbr = 2017, YearName = "2017", YearShortName = "17"},
                new AwardYear { YearNbr = 2018, YearName = "2018", YearShortName = "18"},
                new AwardYear { YearNbr = 2019, YearName = "2019", YearShortName = "19"}
                };

        }


        public class AwardYear
        {
            public int YearNbr { get; set; }
            public string YearName { get; set; }
            public string YearShortName { get; set; }
        }




    }
}