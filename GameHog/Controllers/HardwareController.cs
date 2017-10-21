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
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName");
            return View();
        }

        //// POST: Hardware/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,HardwareName,HardwareDescription,HardwareAvailability,HardwareAvailabilityCount,HardwareShippingUSAOnly,DeveloperName,PublisherName,StoreId")] Hardware hardware)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Hardwares.Add(hardware);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", hardware.StoreId);
        //    return View(hardware);
        //}


        // POST: Hardware/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAjax([Bind(Include = "Id,HardwareName,HardwareDescription,HardwareAvailability,HardwareAvailabilityCount,HardwareShippingUSAOnly,DeveloperName,PublisherName,StoreId")] Hardware hardware)
        {
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", hardware.StoreId);
            if (ModelState.IsValid)
            {

                db.Hardwares.Add(hardware);
                db.SaveChanges();
                return this.Json(new
                {
                    EnableSuccess = true,
                    SuccessTitle = "Success",
                    SuccessMsg = "Success"
                });
            }
            else
            {
                return this.Json(new
                {
                    EnableError = true,
                    ErrorTitle = "Error",
                    ErrorMsg = "Something goes wrong, please try again later"
                });
            }
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
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", hardware.StoreId);
            return View(hardware);
        }

        // POST: Hardware/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HardwareName,HardwareDescription,HardwareAvailability,HardwareAvailabilityCount,HardwareShippingUSAOnly,DeveloperName,PublisherName,StoreId")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hardware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", hardware.StoreId);
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
