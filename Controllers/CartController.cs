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
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            var cart = db.Cart.Include(c => c.MetalItem);
            return View(cart.ToList());
        }

        // GET: Cart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartModels cartModels = db.Cart.Find(id);
            if (cartModels == null)
            {
                return HttpNotFound();
            }
            return View(cartModels);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            ViewBag.MetalItemId = new SelectList(db.MetalItemModels, "ID", "MetalType");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartID,Quantity,MetalItemId")] CartModels cartModels)
        {
            if (ModelState.IsValid)
            {
                MetalItemModels metalItemModels = db.MetalItemModels.Find(cartModels.MetalItemId);
                cartModels.TotalPrice = cartModels.Quantity * metalItemModels.Price;
                cartModels.CartOwner = User.Identity.Name;
                db.Cart.Add(cartModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MetalItemId = new SelectList(db.MetalItemModels, "ID", "MetalType", cartModels.MetalItemId);
            return View(cartModels);
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartModels cartModels = db.Cart.Find(id);
            if (cartModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.MetalItemId = new SelectList(db.MetalItemModels, "ID", "MetalType", cartModels.MetalItemId);
            return View(cartModels);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartID,Quantity,TotalPrice,MetalItemId")] CartModels cartModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MetalItemId = new SelectList(db.MetalItemModels, "ID", "MetalType", cartModels.MetalItemId);
            return View(cartModels);
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartModels cartModels = db.Cart.Find(id);
            if (cartModels == null)
            {
                return HttpNotFound();
            }
            return View(cartModels);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartModels cartModels = db.Cart.Find(id);
            db.Cart.Remove(cartModels);
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
