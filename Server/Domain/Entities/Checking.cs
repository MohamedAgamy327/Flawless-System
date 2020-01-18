using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
	public class Checking
	{
		public int Id { get; set; }
		public string Diagonsis { get; set; }
		public DateTime VisitDate { get; set; }
		public DateTime NextVisitDate { get; set; }
		public VisitTypeEnum VisitType { get; set; }
		public int PatientId { get; set; }
		public Patient Patient { get; set; }
		public ICollection<CheckingMedicine> CheckingMedicines { get; set; }
		public ICollection<CheckingItem> CheckingItems { get; set; }
		public ICollection<CheckingTest> CheckingTests { get; set; }
	}
}
