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
    public class MetalItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MetalItem
        public ActionResult Index()
        {
            var metalItemModels = db.MetalItemModels.Include(m => m.Item);
            return View(metalItemModels.ToList());
        }

        // GET: MetalItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalItemModels metalItemModels = db.MetalItemModels.Find(id);
            if (metalItemModels == null)
            {
                return HttpNotFound();
            }
            return View(metalItemModels);
        }

        // GET: MetalItem/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.ItemModels, "ID", "Type");
            return View();
        }

        // POST: MetalItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,MetalType,Color,Type,File,Price")] MetalItemModels metalItemModels)
        {
            if (ModelState.IsValid)
            {
                db.MetalItemModels.Add(metalItemModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.ItemModels, "ID", "Type", metalItemModels.ItemID);
            return View(metalItemModels);
        }

        // GET: MetalItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalItemModels metalItemModels = db.MetalItemModels.Find(id);
            if (metalItemModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.ItemModels, "ID", "Type", metalItemModels.ItemID);
            return View(metalItemModels);
        }

        // POST: MetalItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemID,MetalType,Color,Type,File,Price")] MetalItemModels metalItemModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metalItemModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.ItemModels, "ID", "Type", metalItemModels.ItemID);
            return View(metalItemModels);
        }

        // GET: MetalItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetalItemModels metalItemModels = db.MetalItemModels.Find(id);
            if (metalItemModels == null)
            {
                return HttpNotFound();
            }
            return View(metalItemModels);
        }

        // POST: MetalItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetalItemModels metalItemModels = db.MetalItemModels.Find(id);
            db.MetalItemModels.Remove(metalItemModels);
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
