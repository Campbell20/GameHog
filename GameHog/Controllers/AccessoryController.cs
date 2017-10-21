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
    //Added a comment to commit changes to master branch
    public class AccessoryController : Controller
    {
        private GameHogContext db = new GameHogContext();

        // GET: Accessory
        public ActionResult Index()
        {
            var accessories = db.Accessories.Include(a => a.Hardwares).Include(a => a.Stores);
            return View(accessories.ToList());
        }

        // GET: Accessory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // GET: Accessory/Create
        public ActionResult Create()
        {
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName");
            return View();
        }

        // POST: Accessory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccessoryName,AccessoryDescription,AccessoryAvailability,AccessoryAvailabilityCount,AccessoryShippingUSAOnly,DeveloperName,PublisherName,StoreId,HardwareId")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName", accessory.HardwareId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", accessory.StoreId);
            return View(accessory);
        }

        // GET: Accessory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName", accessory.HardwareId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", accessory.StoreId);
            return View(accessory);
        }

        // POST: Accessory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccessoryName,AccessoryDescription,AccessoryAvailability,AccessoryAvailabilityCount,AccessoryShippingUSAOnly,DeveloperName,PublisherName,StoreId,HardwareId")] Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName", accessory.HardwareId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", accessory.StoreId);
            return View(accessory);
        }

        // GET: Accessory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessory accessory = db.Accessories.Find(id);
            if (accessory == null)
            {
                return HttpNotFound();
            }
            return View(accessory);
        }

        // POST: Accessory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessory accessory = db.Accessories.Find(id);
            db.Accessories.Remove(accessory);
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
