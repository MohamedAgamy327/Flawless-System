using System.Collections.Generic;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public ICollection<SupplyItem> SupplyItems { get; set; }
        public ICollection<CheckingItem> CheckingItems { get; set; }
    }
}
