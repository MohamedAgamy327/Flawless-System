using System;

namespace API.DTO.Spendings
{
    public class SpendingForGetDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Statement { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
    }
}
