using System;

namespace API.DTO.Patients
{
    public class PatientForGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
    }
}
