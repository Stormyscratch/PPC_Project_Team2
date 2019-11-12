using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPC_Project.Models;

namespace PPC_Project.Controllers
{
    public class InstallmentContractsController : Controller
    {
        private Team2Entities db = new Team2Entities();

        // GET: InstallmentContracts
        public ActionResult Index()
        {
            var installmentContracts = db.InstallmentContracts.Include(i => i.Property);
            return View(installmentContracts.ToList());
        }

        // GET: InstallmentContracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstallmentContract installmentContract = db.InstallmentContracts.Find(id);
            if (installmentContract == null)
            {
                return HttpNotFound();
            }
            return View(installmentContract);
        }

        // GET: InstallmentContracts/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode");
            return View();
        }

        // POST: InstallmentContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,InstallmentContractCode,CustomerName,YearOfBirth,SSN,CustomerAddress,Mobile,PropertyID,DateOfContract,InstallmentPaymentMethod,PaymentPeriod,Price,Deposit,LoanAmount,Taken,Remain,Status")] InstallmentContract installmentContract)
        {
            if (ModelState.IsValid)
            {
                db.InstallmentContracts.Add(installmentContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode", installmentContract.PropertyID);
            return View(installmentContract);
        }

        // GET: InstallmentContracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstallmentContract installmentContract = db.InstallmentContracts.Find(id);
            if (installmentContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode", installmentContract.PropertyID);
            return View(installmentContract);
        }

        // POST: InstallmentContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,InstallmentContractCode,CustomerName,YearOfBirth,SSN,CustomerAddress,Mobile,PropertyID,DateOfContract,InstallmentPaymentMethod,PaymentPeriod,Price,Deposit,LoanAmount,Taken,Remain,Status")] InstallmentContract installmentContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(installmentContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode", installmentContract.PropertyID);
            return View(installmentContract);
        }

        // GET: InstallmentContracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstallmentContract installmentContract = db.InstallmentContracts.Find(id);
            if (installmentContract == null)
            {
                return HttpNotFound();
            }
            return View(installmentContract);
        }

        // POST: InstallmentContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstallmentContract installmentContract = db.InstallmentContracts.Find(id);
            db.InstallmentContracts.Remove(installmentContract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
