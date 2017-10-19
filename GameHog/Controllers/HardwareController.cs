using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameHog.Data;
using GameHog.Models;

namespace GameHog.Controllers
{
    public class HardwareController : Controller
    {
        private GameHogContext db = new GameHogContext();

        // GET: Hardware
        public ActionResult Index()
        {
            var hardwares = db.Hardwares.Include(h => h.Stores);
            return View(hardwares.ToList());
        }

        // GET: Hardware/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardwares.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // GET: Hardware/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: Hardware/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HardwareId,HardwareName,HardwareDescription,HardwareAvailability,HardwareAvailabilityCount,HardwareShippingUSAOnly,HardwareUPCCode,HardwareESRBRating,DeveloperName,PublisherName")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                db.Hardwares.Add(hardware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Stores, "StoreId", "StoreName", hardware.Id);
            return View(hardware);
        }

        // GET: Hardware/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardwares.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Stores, "StoreId", "StoreName", hardware.Id);
            return View(hardware);
        }

        // POST: Hardware/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HardwareId,HardwareName,HardwareDescription,HardwareAvailability,HardwareAvailabilityCount,HardwareShippingUSAOnly,HardwareUPCCode,HardwareESRBRating,DeveloperName,PublisherName")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hardware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Stores, "StoreId", "StoreName", hardware.Id);
            return View(hardware);
        }

        // GET: Hardware/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hardware hardware = db.Hardwares.Find(id);
            if (hardware == null)
            {
                return HttpNotFound();
            }
            return View(hardware);
        }

        // POST: Hardware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hardware hardware = db.Hardwares.Find(id);
            db.Hardwares.Remove(hardware);
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
