using System;

namespace Domain.Entities
{
    public class Waiting
    {
        public DateTime Date { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? EnterDate { get; set; }
        public int Order { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
