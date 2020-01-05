namespace API.DTO.Medicines
{
    public class MedicineForAddDTO
    {
        public string Name { get; set; }
        public int MedicineTypeId { get; set; }
        public int FrequencyId { get; set; }
        public int Duration { get; set; }
    }
}
