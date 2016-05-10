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
    public class OfferDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferDetail
        public ActionResult Index()
        {
            var offerDetail = db.OfferDetail.Include(o => o.MetalItem);
            return View(offerDetail.ToList());
        }

        // GET: OfferDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDetailModels offerDetailModels = db.OfferDetail.Find(id);
            if (offerDetailModels == null)
            {
                return HttpNotFound();
            }
            return View(offerDetailModels);
        }

        // GET: OfferDetail/Create
        public ActionResult Create()
        {
            ViewBag.MetalItemID = new SelectList(db.MetalItemModels, "ID", "MetalType");
            return View();
        }

        // POST: OfferDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OfferId,UnitPrice,Quantity,MetalItemID")] OfferDetailModels offerDetailModels)
        {
            if (ModelState.IsValid)
            {
                db.OfferDetail.Add(offerDetailModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MetalItemID = new SelectList(db.MetalItemModels, "ID", "MetalType", offerDetailModels.MetalItemID);
            return View(offerDetailModels);
        }

        // GET: OfferDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDetailModels offerDetailModels = db.OfferDetail.Find(id);
            if (offerDetailModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.MetalItemID = new SelectList(db.MetalItemModels, "ID", "MetalType", offerDetailModels.MetalItemID);
            return View(offerDetailModels);
        }

        // POST: OfferDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OfferId,UnitPrice,Quantity,MetalItemID")] OfferDetailModels offerDetailModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerDetailModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MetalItemID = new SelectList(db.MetalItemModels, "ID", "MetalType", offerDetailModels.MetalItemID);
            return View(offerDetailModels);
        }

        // GET: OfferDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferDetailModels offerDetailModels = db.OfferDetail.Find(id);
            if (offerDetailModels == null)
            {
                return HttpNotFound();
            }
            return View(offerDetailModels);
        }

        // POST: OfferDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferDetailModels offerDetailModels = db.OfferDetail.Find(id);
            db.OfferDetail.Remove(offerDetailModels);
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
