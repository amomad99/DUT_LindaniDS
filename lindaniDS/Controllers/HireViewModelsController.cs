using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lindaniDS.Models;
using lindaniDS.ViewModels;

namespace lindaniDS.Controllers
{
    public class HireViewModelsController : Controller
    {
        private LindaniContext db = new LindaniContext();
        private DbSet<Address> Address;

        //public DbSet<Address> Address { get; private set; }

        // GET: HireViewModels
        public ActionResult Index()
        {
            var hireViewModels = db.HireViewModels.Include(h => h.Address).Include(h => h.User).Include(h => h.VehicleHire);
            var Hire = new HireViewModelsController
            {
                Address = db.Addresses
            };
           // var vehicleHires = db.VehicleHires.Include(v => v.VehicleModel);
            ViewBag.hired = db.VehicleHires.Where(s => s.availability).Count();
            ViewBag.dCar = db.VehicleHires.Where(a => a.condition).Count();
            ViewBag.vehicles = db.VehicleHires.ToList();

            return View(hireViewModels);
        }

        // GET: HireViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HireViewModels hireViewModels = db.HireViewModels.Find(id);
            if (hireViewModels == null)
            {
                return HttpNotFound();
            }
            return View(hireViewModels);
        }

        // GET: HireViewModels/Create
        public ActionResult Create()
        {
            ViewBag.AddreessID = new SelectList(db.Addresses, "AddreessID", "Country");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email");
           // ViewBag.color = new SelectList(db.VehicleHires, "color", "color");
            return View();
        }

        // POST: HireViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HireID,vehicleID,UserID,PickDate,DropDate,AddreessID")] HireViewModels hireViewModels)
        {
            if (ModelState.IsValid)
            {
                db.HireViewModels.Add(hireViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddreessID = new SelectList(db.Addresses, "AddreessID", "Country", hireViewModels.AddreessID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", hireViewModels.UserID);
            ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email", hireViewModels.vehicleID);
            return View(hireViewModels);
        }

        // GET: HireViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HireViewModels hireViewModels = db.HireViewModels.Find(id);
            if (hireViewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddreessID = new SelectList(db.Addresses, "AddreessID", "Country", hireViewModels.AddreessID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", hireViewModels.UserID);
            ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email", hireViewModels.vehicleID);
            return View(hireViewModels);
        }

        // POST: HireViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HireID,vehicleID,UserID,PickDate,DropDate,AddreessID")] HireViewModels hireViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hireViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddreessID = new SelectList(db.Addresses, "AddreessID", "Country", hireViewModels.AddreessID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", hireViewModels.UserID);
            ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email", hireViewModels.vehicleID);
            return View(hireViewModels);
        }

        // GET: HireViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HireViewModels hireViewModels = db.HireViewModels.Find(id);
            if (hireViewModels == null)
            {
                return HttpNotFound();
            }
            return View(hireViewModels);
        }

        // POST: HireViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HireViewModels hireViewModels = db.HireViewModels.Find(id);
            db.HireViewModels.Remove(hireViewModels);
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
