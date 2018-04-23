using System.Web.Mvc;

namespace SIAWeb.Controllers
{
    public class AdminController : Controller
    {


        [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
        public ActionResult Index()
        {

            return View();

        }



    }
}
