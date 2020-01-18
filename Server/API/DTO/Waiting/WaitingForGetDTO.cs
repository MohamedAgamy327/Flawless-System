using System;

namespace API.DTO.Waiting
{
    public class WaitingForGetDTO
    {
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime? CanceledDate { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public int Order { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientTelephone { get; set; }
    }
}
