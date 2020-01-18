using System;

namespace API.DTO.Checking
{
    public class CheckingForGetDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Diagonsis { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime NextVisitDate { get; set; }
        public string VisitType { get; set; }
    }
}
