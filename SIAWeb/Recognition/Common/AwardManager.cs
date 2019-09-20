using RecognitionBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recognition.Common
{
    public class AwardManager
    {
        SAPDActivityEntities db;

        public AwardManager()
        {
            db = new SAPDActivityEntities();
        }


    }
}