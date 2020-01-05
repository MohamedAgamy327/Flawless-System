namespace Domain.Entities
{
    public class SupplyItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SupplyId { get; set; }
        public Supply Supply { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
    }
}
