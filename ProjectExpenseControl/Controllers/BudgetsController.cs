using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectExpenseControl.CustomAuthentication;
using ProjectExpenseControl.DataAccess;
using ProjectExpenseControl.Models;
using ProjectExpenseControl.Services;

namespace ProjectExpenseControl.Controllers
{
    [CustomAuthorize(Roles = "Administrador, JefeArea")]
    public class BudgetsController : Controller
    {
        private BudgetRepository _db;
        private AreaRepository _area;
        private AccountingAccountRepository _accountingAccount;
        public BudgetsController()
        {
            _db = new BudgetRepository();
            _area = new AreaRepository();
            _accountingAccount = new AccountingAccountRepository();
        }

        // GET: Budgets
        public ActionResult Index()
        {
            return View(_db.GetAll());
        }

        // GET: Budgets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = _db.GetOne(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // GET: Budgets/Create
        public ActionResult Create()
        {
            ViewBag.listaAreas = _area.GetAll();
            ViewBag.listaCuentas = _accountingAccount.GetAll();
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BUD_IDE_BUDGET,BUD_IDE_USER,BUD_IDE_ACCOUNT,BUD_IDE_AREA,BUD_DES_QUANTITY,BUD_DES_PERIOD,BUD_FH_CREATED")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                var user = (CustomSerializeModel)Session["user"];

                if(user != null)
                {
                    budget.BUD_FH_CREATED = DateTime.Now;
                    budget.BUD_IDE_USER = user.UserId;
                    if (_db.Create(budget))
                        return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Logout","Account");
                }
            }

            return View(budget);
        }

        // GET: Budgets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = _db.GetOne(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            ViewBag.listaAreas = _area.GetAll();
            ViewBag.listaCuentas = _accountingAccount.GetAll();
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BUD_IDE_BUDGET,BUD_IDE_USER,BUD_IDE_ACCOUNT,BUD_IDE_AREA,BUD_DES_QUANTITY,BUD_DES_PERIOD")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                if(_db.Update(budget))
                    return RedirectToAction("Index");
            }
            ViewBag.listaAreas = _area.GetAll();
            ViewBag.listaCuentas = _accountingAccount.GetAll();
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = _db.GetOne(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if(_db.Delete(id))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete/"+id);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
