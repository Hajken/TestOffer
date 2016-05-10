using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestOffer.Models;

namespace TestOffer.ViewModels
{
    public class ItemViewModel
    {
        public List<ItemModels> Items { get; set; }
        public List<MetalItemModels> MetalItems { get; set; }


    }
}