using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public GenderEnum Gender { get; set; }
    }
}
