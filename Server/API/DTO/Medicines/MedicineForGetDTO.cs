namespace API.DTO.Medicines
{
    public class MedicineForGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicineTypeId { get; set; }
        public string MedicineTypeName { get; set; }
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public int Duration { get; set; }
    }
}
