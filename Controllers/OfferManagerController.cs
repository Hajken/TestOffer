using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using TestOffer.Models;
using TestOffer.ViewModels;

namespace TestOffer.Controllers
{
    public class OfferManagerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ItemViewModel itemList = new ItemViewModel();

        // GET: OfferManager
        public ActionResult Index()
        {
            //Get all items from Database and add to ItemViewModel
            itemList.Items = db.ItemModels.ToList();
            var metalItemModels = db.MetalItemModels.Include(p => p.Item);
            itemList.MetalItems = metalItemModels.ToList();

            return View(itemList);
        }


        public ActionResult AddToCart()
        {


            return View();
        }
    }
}
