namespace API.DTO.Supply
{
    public class SupplyItemForGetDTO
    {
        public int ItemId { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
    }
}
