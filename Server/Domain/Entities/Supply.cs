using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Supply
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public ICollection<SupplyItem> SupplyItems { get; set; }
    }
}
