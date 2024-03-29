﻿using System;

namespace API.DTO.Patients
{
    public class PatientForGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string Age { get; set; }
    }
}
