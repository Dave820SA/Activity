using System.Linq;
using System.Web.Mvc;
using PersonnelBusinessLayer;
using SIAWeb.Common;
using System;

namespace SIAWeb.Controllers
{
    public class GroupMemberAddController : Controller
    {
        
        public ActionResult Index(int id, string search_string)
        {
            
             //Load all Group members into Viewdata
            GroupMemberList gm = new GroupMemberList();
            ViewData["MyMembers"] = gm.GetGroupMemberList(id);

            ViewBag.GroupName = _getGroupName(id);
            ViewBag.GroupID = id;
            
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

        [HttpPost]
        public void addmembers(int _appEntity, int _group)
        {
            GroupMemberList addMember = new GroupMemberList();
            addMember.AddGroupMember(_appEntity, _group);

             //RedirectToAction("Index", "GroupMemberAdd");

            //Load all Group members into Viewdata
            //GroupMemberList gm = new GroupMemberList();
            //ViewData["MyMembers"] = gm.GetGroupMemberList(_group);
        }

    }
}
