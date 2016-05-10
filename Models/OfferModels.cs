using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestOffer.Models
{
    public partial class OfferModels
    {
        public int ID { get; set; }

        public string OfferName { get; set; }

        public string Address { get; set; }

        public string ContactInfo { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OfferDate { get; set; }

        public List<OfferDetailModels> OfferDetails { get; set; }

    }
}