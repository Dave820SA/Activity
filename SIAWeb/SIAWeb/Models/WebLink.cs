using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIAWebLinksBusinessLayer;
using System.Web.Mvc;

namespace SIAWeb.Models
{

    public class webLink
        {
            public int category { get; set; }
            public string link { get; set; }
            public string linkPath { get; set; }
        }   

    //public class WebLinkManager
    //{
    //    public List<webLink> GetWebLinks()
    //        {
    //            WebLinksEntities db = new WebLinksEntities();

    //            var mylinks = from u in db.WebLinks
    //                            select u;

    //            var selectList = new List<webLink>();

    //            foreach (var U in mylinks)
    //            {
    //                selectList.Add(new webLink { category = U.WebCategoryID, link = U.Name.ToString(), linkPath = U.WebLink.ToString() });
    //            }
    //            return selectList;
    //        }
    //}
   
} 
