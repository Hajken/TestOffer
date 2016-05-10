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
    public class OfferController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offer
        public ActionResult Index()
        {
            return View(db.Offer.ToList());
        }

        // GET: Offer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferModels offerModels = db.Offer.Find(id);
            if (offerModels == null)
            {
                return HttpNotFound();
            }
            return View(offerModels);
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OfferName,Address,ContactInfo,TotalPrice,OfferDate")] OfferModels offerModels)
        {
            if (ModelState.IsValid)
            {
                db.Offer.Add(offerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offerModels);
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferModels offerModels = db.Offer.Find(id);
            if (offerModels == null)
            {
                return HttpNotFound();
            }
            return View(offerModels);
        }

        // POST: Offer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OfferName,Address,ContactInfo,TotalPrice,OfferDate")] OfferModels offerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offerModels);
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferModels offerModels = db.Offer.Find(id);
            if (offerModels == null)
            {
                return HttpNotFound();
            }
            return View(offerModels);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferModels offerModels = db.Offer.Find(id);
            db.Offer.Remove(offerModels);
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
