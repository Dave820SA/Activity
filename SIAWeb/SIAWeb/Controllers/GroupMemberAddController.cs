using System.Linq;
using System.Web.Mvc;
using PersonnelBusinessLayer;
using SIAWeb.Common;
using System;

namespace SIAWeb.Controllers
{
    public class GroupMemberAddController : Controller
    {
        //
        // GET: /GroupMemberAdd/

        //public ActionResult Index(int id = 0 )
        //{
        //    if (id > 0)
        //    {
        //        GroupMemberList gm = new GroupMemberList();

        //        return View(gm.GetGroupMemberList(id));
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

        public ActionResult Index(string search_string)
        {
            if (!String.IsNullOrEmpty(search_string))
            {
                GetPeople mySearch = new GetPeople();

                return View(mySearch.GetSearchedEmployed(search_string));
            }
            else
            {
                return View();
            }

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
