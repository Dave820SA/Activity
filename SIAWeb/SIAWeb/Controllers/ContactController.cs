using System.Web.Mvc;
using SIAWeb.Common;
using PersonnelBusinessLayer;
using System.Linq;

namespace SIAWeb.Controllers
{
    public class ContactController : Controller
    {
       GetGroupMembers db = new GetGroupMembers();

        public ActionResult Index()
        {
            ViewBag.GroupName = _getGroupName(1);
            return View(db.GetGroupMemberInfo(1));

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
