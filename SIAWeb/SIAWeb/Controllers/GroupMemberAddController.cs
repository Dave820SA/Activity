using System.Linq;
using System.Web.Mvc;
using PersonnelBusinessLayer;
using SIAWeb.Common;

namespace SIAWeb.Controllers
{
    public class GroupMemberAddController : Controller
    {
        //
        // GET: /GroupMemberAdd/

        GetGroupMembers db = new GetGroupMembers();

        public ActionResult Index(int id)
        {
            ViewBag.GroupName = _getGroupName(id);
            return View(db.GetGroupMemberInfo(id));

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
