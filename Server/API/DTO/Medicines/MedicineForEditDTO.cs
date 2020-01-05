namespace API.DTO.Medicines
{
    public class MedicineForEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicineTypeId { get; set; }
        public int FrequencyId { get; set; }
        public int Duration { get; set; }
    }
}
