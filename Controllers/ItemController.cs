using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestOffer.Models;

namespace TestOffer.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Item
        public ActionResult Index()
        {
            return View(db.ItemModels.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModels itemModels = db.ItemModels.Find(id);
            if (itemModels == null)
            {
                return HttpNotFound();
            }
            return View(itemModels);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] ItemModels itemModels)
        {
            if (ModelState.IsValid)
            {
                db.ItemModels.Add(itemModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemModels);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModels itemModels = db.ItemModels.Find(id);
            if (itemModels == null)
            {
                return HttpNotFound();
            }
            return View(itemModels);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] ItemModels itemModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemModels);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModels itemModels = db.ItemModels.Find(id);
            if (itemModels == null)
            {
                return HttpNotFound();
            }
            return View(itemModels);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModels itemModels = db.ItemModels.Find(id);
            db.ItemModels.Remove(itemModels);
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
