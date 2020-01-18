using System;
using System.Collections.Generic;

namespace API.DTO.Checking
{
    public class CheckingForAddDTO
    {
        public string Diagonsis { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string VisitType { get; set; }
        public int PatientId { get; set; }
        public ICollection<CheckingItemForAddDTO> CheckingItems { get; set; }
        public ICollection<CheckingTestForAddDTO> CheckingTests { get; set; }
        public ICollection<CheckingMedicineForAddDTO> CheckingMedicines { get; set; }
    }
}
