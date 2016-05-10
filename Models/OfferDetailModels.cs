namespace TestOffer.Models
{
    public class OfferDetailModels
    {
        public int ID { get; set; }
        public int OfferId { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public int MetalItemID { get; set; }
        public virtual MetalItemModels MetalItem { get; set; }
        
    }
}