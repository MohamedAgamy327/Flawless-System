using System;

namespace Domain.Entities
{
    public class Spending
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Statement { get; set; }
        public decimal Amount { get; set; }
    }
}
