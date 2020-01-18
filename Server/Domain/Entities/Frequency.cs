using System.Collections.Generic;

namespace Domain.Entities
{
    public class Frequency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
        public ICollection<CheckingMedicine> CheckingMedicines { get; set; }
    }
}
