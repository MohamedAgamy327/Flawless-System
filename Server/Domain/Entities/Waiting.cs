using System;

namespace Domain.Entities
{
    public class Waiting
    {
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime? CanceledDate { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public int Order { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
