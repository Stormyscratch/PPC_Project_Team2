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
    public class FullContractsController : Controller
    {
        private Team2Entities db = new Team2Entities();

        // GET: FullContracts
        public ActionResult Index()
        {
            var fullContracts = db.FullContracts.Include(f => f.Property);
            return View(fullContracts.ToList());
        }

        // GET: FullContracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullContract fullContract = db.FullContracts.Find(id);
            if (fullContract == null)
            {
                return HttpNotFound();
            }
            return View(fullContract);
        }

        // GET: FullContracts/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode");
            return View();
        }

        // POST: FullContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FullContractCode,CustomerName,YearOfBirth,SSN,CustomerAddress,Mobile,PropertyID,DateOfContract,Price,Deposit,Remain,Status")] FullContract fullContract)
        {
            if (ModelState.IsValid)
            {
                db.FullContracts.Add(fullContract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode", fullContract.PropertyID);
            return View(fullContract);
        }

        // GET: FullContracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullContract fullContract = db.FullContracts.Find(id);
            if (fullContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode", fullContract.PropertyID);
            return View(fullContract);
        }

        // POST: FullContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FullContractCode,CustomerName,YearOfBirth,SSN,CustomerAddress,Mobile,PropertyID,DateOfContract,Price,Deposit,Remain,Status")] FullContract fullContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.Properties, "ID", "PropertyCode", fullContract.PropertyID);
            return View(fullContract);
        }

        // GET: FullContracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullContract fullContract = db.FullContracts.Find(id);
            if (fullContract == null)
            {
                return HttpNotFound();
            }
            return View(fullContract);
        }

        // POST: FullContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FullContract fullContract = db.FullContracts.Find(id);
            db.FullContracts.Remove(fullContract);
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
