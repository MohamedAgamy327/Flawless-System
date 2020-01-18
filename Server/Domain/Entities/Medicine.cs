using System.Collections.Generic;

namespace Domain.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicineTypeId { get; set; }
        public MedicineType MedicineType { get; set; }
        public int FrequencyId { get; set; }
        public Frequency Frequency { get; set; }
        public int Duration { get; set; }
        public ICollection<CheckingMedicine> CheckingMedicines { get; set; }
    }
}
