using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestOffer.Models
{
    public class MetalItemModels
    {
        public int ID { get; set; }


        public int ItemID { get; set; }


        public virtual ItemModels Item { get; set; }


        public string MetalType { get; set; }


        public string Color { get; set; }

        [Display(Name = "Type Of Metal Work")]
        public string Type { get; set; }

        [Display(Name = "Picture link")]
        public string File { get; set; }


        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }


    }
}