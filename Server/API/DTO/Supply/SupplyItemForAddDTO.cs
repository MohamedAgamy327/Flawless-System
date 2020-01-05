namespace API.DTO.Supply
{
    public class SupplyItemForAddDTO
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
    }
}
