using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lindaniDS.Models;

namespace lindaniDS.Controllers
{
    public class PaymentsController : Controller
    {
        private LindaniContext db = new LindaniContext();

        // GET: Payments
        public ActionResult Index(int? id)
        {
            var payments = db.Payments.Include(p => p.BookingPackages).Include(p => p.User).Include(p => p.VehicleHire);
            var vehicleHires = db.VehicleHires.Find(id);
            ViewBag.Vehicle = db.VehicleHires.Where(s => s.vehicleID == id);
            ViewBag.test = vehicleHires.Email;
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        public ActionResult AddPay(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicleHires = db.VehicleHires.Find(id);
            Session["Vehicle"] = vehicleHires;
            //  Session["Vehicle"].Clear();
            if (vehicleHires == null)
            {
                return HttpNotFound();
            }
            //return View(vehicleHires);

             return RedirectToAction("Create", "Payments");

        }
        //////////////////////////////////////////
        public ActionResult VehiclePay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleHire vehicleHire =  db.VehicleHires.Find(id);
            if (vehicleHire == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelID = new SelectList(db.VehicleModels, "modelID", "vehicleName", vehicleHire.modelID);
            return View(vehicleHire);
        }
        ////////        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VehiclePay([Bind(Include = "vehicleID,modelID,Email,color,regNo,noPlate,cost,condition,availability")] VehicleHire vehicleHire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleHire).State = EntityState.Modified;
                 db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.modelID = new SelectList(db.VehicleModels, "modelID", "vehicleName", vehicleHire.modelID);
            return View(vehicleHire);
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Payments/Create
        public ActionResult Create(int? id)
        {
            Session.Timeout = 60;


            if (Session["Email"] != null)
            {
                ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name");
                ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
                ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email");
               // ViewBag.Vehicle = Session["Vehicle"];
                return View();
            }
            else
            {
              
                return Redirect(Request.UrlReferrer.ToString());
            }
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Payment payment)
        {
            // [Bind(Include = "PaymentID,PayType,UserID,vehicleID,PackageID,Date,BankName,BranchCode,CardNumber,Expire,CVV")]
            Session.Timeout = 60;
            if (Session["Email"] != null && Session["Vehicle"] != null)
                {
                    if (ModelState.IsValid)
                    {
                   // var UserID = Session["UserID"];
                        // db.Payments.Add((Payment)UserID);
                        db.Payments.Add(payment);
                        db.SaveChanges();
                        //Session["Vehicle"].Clear();
                    return RedirectToAction("Index");
                    }

                    ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name", payment.PackageID);
                    ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", payment.UserID);
                    ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email", payment.vehicleID);
                    return View(payment);
                }
                else
                {

                    return Redirect(Request.UrlReferrer.ToString());
                }
            }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name", payment.PackageID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", payment.UserID);
            ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email", payment.vehicleID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,PayType,UserID,vehicleID,PackageID,Date,BankName,BranchCode,CardNumber,Expire,CVV")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name", payment.PackageID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", payment.UserID);
            ViewBag.vehicleID = new SelectList(db.VehicleHires, "vehicleID", "Email", payment.vehicleID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

/*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
