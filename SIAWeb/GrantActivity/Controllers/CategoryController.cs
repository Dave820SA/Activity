using System.Data;
using System.Linq;
using System.Web.Mvc;
using GrantBusinessLayer;

namespace GrantActivity.Controllers
{
    [AuthorizeUserAccessLevel(UserRole = "Superuser, Admin")]
    public class CategoryController : Controller
    {
        private GrantEntities db = new GrantEntities();

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(db.Grant_Category.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Grant_Category grant_category = db.Grant_Category.Single(g => g.CategoryID == id);
            if (grant_category == null)
            {
                return HttpNotFound();
            }
            return View(grant_category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Grant_Category grant_category)
        {
            if (ModelState.IsValid)
            {
                db.Grant_Category.AddObject(grant_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grant_category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Grant_Category grant_category = db.Grant_Category.Single(g => g.CategoryID == id);
            if (grant_category == null)
            {
                return HttpNotFound();
            }
            return View(grant_category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Grant_Category grant_category)
        {
            if (ModelState.IsValid)
            {
                db.Grant_Category.Attach(grant_category);
                db.ObjectStateManager.ChangeObjectState(grant_category, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grant_category);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Grant_Category grant_category = db.Grant_Category.Single(g => g.CategoryID == id);
            if (grant_category == null)
            {
                return HttpNotFound();
            }
            return View(grant_category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grant_Category grant_category = db.Grant_Category.Single(g => g.CategoryID == id);
            db.Grant_Category.DeleteObject(grant_category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}