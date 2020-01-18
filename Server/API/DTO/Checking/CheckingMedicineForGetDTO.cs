namespace API.DTO.Checking
{
    public class CheckingMedicineForGetDTO
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int MedicineTypeId { get; set; }
        public string MedicineTypeName { get; set; }
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public int Duration { get; set; }
    }
}
