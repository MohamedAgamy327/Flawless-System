using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Code { get; set; }
        public string Age { get; set; }
        public GenderEnum Gender { get; set; }
        public ICollection<Waiting> Waitings { get; set; }
        public ICollection<Checking> Checkings { get; set; }
    }
}
