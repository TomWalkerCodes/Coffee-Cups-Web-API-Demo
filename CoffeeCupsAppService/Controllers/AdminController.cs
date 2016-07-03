using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeCupsAppService.DataObjects;
using CoffeeCupsAppService.Models;

namespace CoffeeCupsAppService.Controllers
{
    public class AdminController : Controller
    {
        private CoffeeCupsAppContext db = new CoffeeCupsAppContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Cups.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupOfCoffee cupOfCoffee = db.Cups.Find(id);
            if (cupOfCoffee == null)
            {
                return HttpNotFound();
            }
            return View(cupOfCoffee);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,AzureVersion,DateUtc,MadeAtHome,OS,Version,CreatedAt,UpdatedAt,Deleted")] CupOfCoffee cupOfCoffee)
        {
            if (ModelState.IsValid)
            {
                db.Cups.Add(cupOfCoffee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cupOfCoffee);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupOfCoffee cupOfCoffee = db.Cups.Find(id);
            if (cupOfCoffee == null)
            {
                return HttpNotFound();
            }
            return View(cupOfCoffee);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,AzureVersion,DateUtc,MadeAtHome,OS,Version,CreatedAt,UpdatedAt,Deleted")] CupOfCoffee cupOfCoffee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupOfCoffee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cupOfCoffee);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CupOfCoffee cupOfCoffee = db.Cups.Find(id);
            if (cupOfCoffee == null)
            {
                return HttpNotFound();
            }
            return View(cupOfCoffee);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CupOfCoffee cupOfCoffee = db.Cups.Find(id);
            db.Cups.Remove(cupOfCoffee);
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
