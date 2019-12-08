using System;

namespace API.DTO.Spendings
{
    public class SpendingForGetDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string statement { get; set; }
    }
}
