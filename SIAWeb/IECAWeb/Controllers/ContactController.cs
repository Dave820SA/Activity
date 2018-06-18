using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IECAWeb.Models;
using PersonnelBusinessLayer;

namespace IECAWeb.Controllers
{
    public class ContactController : Controller
    {
        GetGroupMembers db = new GetGroupMembers();
        //
        // GET: /Groups/Contact/

        public ActionResult Index(int id = 0)
        {
            int x;
            if (id > 0)
            {
                x = id;
            }
            else
            {
                x = 1;
            }

            ViewBag.GroupName = _getGroupName(x);
            return View(db.GetGroupMemberInfo(x));
            //return View();
        }

        private string _getGroupName(int id)
        {
            PersonnelContext mdb = new PersonnelContext();

            return (from n in mdb.GroupTitles
                    where n.GroupTitleID == id
                    select n.Name).FirstOrDefault();

        }

    }
}

