using ProjectExpenseControl.CustomAuthentication;
using ProjectExpenseControl.DataAccess;
using ProjectExpenseControl.Models;
using ProjectExpenseControl.Services;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectExpenseControl.Controllers
{
    [CustomAuthorize(Roles = "Administrador")]
    public class AreasController : Controller
    {
        private AuthenticationDB db = new AuthenticationDB();
        private AreaRepository _db;
        public AreasController()
        {
            _db = new AreaRepository();
        }


        // GET: Areas
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        // GET: Areas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = _db.GetOne(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ARE_IDE_AREA,ARE_DES_NAME,ARE_FH_CREATED")] Area area)
        {
            if (ModelState.IsValid)
            {
                area.ARE_FH_CREATED = DateTime.Now;
                if(_db.Create(area))
                    return RedirectToAction("Index");
            }
            
            return View(area);
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = _db.GetOne(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ARE_IDE_AREA,ARE_DES_NAME,ARE_FH_CREATED")] Area area)
        {
            if (ModelState.IsValid)
            {
                if(_db.Update(area))
                    return RedirectToAction("Index");
            }
            return View(area);
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = _db.GetOne(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            if(_db.Delete(id))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete/" + id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetAreas()
        {
            var dbResult = db.Areas.ToList();
            var areas = (from area in dbResult
                             select new
                             {
                                 area.ARE_IDE_AREA,
                                 area.ARE_DES_NAME
                             });
            return Json(areas, JsonRequestBehavior.AllowGet);
        }
    }
}
