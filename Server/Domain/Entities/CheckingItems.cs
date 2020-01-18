namespace Domain.Entities
{
    public class CheckingItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int CheckingId { get; set; }
        public Checking Checking { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

    }
}
