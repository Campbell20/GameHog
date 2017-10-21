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
    public class GameController : Controller
    {
        private GameHogContext db = new GameHogContext();

        // GET: Game
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Genres).Include(g => g.Hardwares).Include(g => g.Stores);
            return View(games.ToList());
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName");
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName");
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameName,GameDescription,GameAvailability,GameAvailabilityCount,GameShippingUSAOnly,GameESRBRating,DeveloperName,PublisherName,StoreId,HardwareId,GenreId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName", game.GenreId);
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName", game.HardwareId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", game.StoreId);
            return View(game);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName", game.GenreId);
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName", game.HardwareId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", game.StoreId);
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameName,GameDescription,GameAvailability,GameAvailabilityCount,GameShippingUSAOnly,GameESRBRating,DeveloperName,PublisherName,StoreId,HardwareId,GenreId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName", game.GenreId);
            ViewBag.HardwareId = new SelectList(db.Hardwares, "Id", "HardwareName", game.HardwareId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "StoreName", game.StoreId);
            return View(game);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
