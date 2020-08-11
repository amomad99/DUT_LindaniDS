using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lindaniDS.Models;

namespace lindaniDS.Controllers
{
    public class LearnersController : Controller
    {
        private LindaniContext db = new LindaniContext();

        // GET: Learners
        public async Task<ActionResult> Index()
        {
            var learners = db.Learners;
            return View(await learners.ToListAsync());
        }
        public async Task<ActionResult> AdminView()
        {
            var learners = db.Learners;
            return View(await learners.ToListAsync());
        }

        // GET: Learners/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Learners learners = await db.Learners.FindAsync(id);
            if (learners == null)
            {
                return HttpNotFound();
            }
            return View(learners);
        }

        // GET: Learners/Create
        public ActionResult Create()
        {
           // ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name");
          //  ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Learners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LearnerID,Province,City,Surbub,Street,ZipCode,Phone,IDNum,Location,BookingDate,Session,Names,Email,")] Learners learners)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learners);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

           // ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name", learners.PackageID);
           // ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", learners.UserID);
            return View(learners);
        }

        // GET: Learners/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Learners learners = await db.Learners.FindAsync(id);
            if (learners == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name", learners.PackageID);
          //  ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", learners.UserID);
            return View(learners);
        }

        // POST: Learners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LearnerID,Province,City,Surbub,Street,ZipCode,Phone,IDNum,Location,BookingDate,Session")] Learners learners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(learners).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
          //  ViewBag.PackageID = new SelectList(db.BookingPackages, "PackageID", "Name", learners.PackageID);
          //  ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", learners.UserID);
            return View(learners);
        }

        // GET: Learners/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Learners learners = await db.Learners.FindAsync(id);
            if (learners == null)
            {
                return HttpNotFound();
            }
            return View(learners);
        }

        // POST: Learners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Learners learners = await db.Learners.FindAsync(id);
            db.Learners.Remove(learners);
            await db.SaveChangesAsync();
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
