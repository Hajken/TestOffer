using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestOffer.Models;

namespace TestOffer.ViewModels
{
    public class CartViewModel
    {
        public List<CartModels> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}