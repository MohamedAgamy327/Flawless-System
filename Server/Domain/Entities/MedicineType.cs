using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class MedicineType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}
