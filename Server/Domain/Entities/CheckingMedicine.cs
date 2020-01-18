namespace Domain.Entities
{
    public class CheckingMedicine
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int CheckingId { get; set; }
        public Checking Checking { get; set; }
        public int FrequencyId { get; set; }
        public Frequency Frequency { get; set; }
        public int Duration { get; set; }

    }
}
