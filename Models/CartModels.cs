using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestOffer.Models
{
    public class CartModels
    {
        private DateTime _date = DateTime.Now;

        [Key]
        public int CartID { get; set; }


        public string CartOwner { get; set; }

        [Display(Name = "Quantity/Meter")]
        public int Quantity { get; set; }

        public DateTime DateCreated {
            get { return _date; }
            set { _date = value; }
        }

       
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        public int MetalItemId { get; set; }
        public virtual MetalItemModels MetalItem { get; set; }

    }
}