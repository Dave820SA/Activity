using System.Web.Mvc;
using SIAWebLinksBusinessLayer;
using SIAWeb.Common;

namespace SIAWeb.Controllers
{
    public class ContactController : Controller
    {
       

        public ActionResult Index()
        {
            GetGroupMembers myGroupMembers = new GetGroupMembers();

            return View(myGroupMembers.GetGroupMemberInfo(1));

        }

       

    }
}
