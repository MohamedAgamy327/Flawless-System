using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class CheckingMedicineMap
    {
        public CheckingMedicineMap(EntityTypeBuilder<CheckingMedicine> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.MedicineId, t.CheckingId });
            entityBuilder.HasOne(h => h.Frequency).WithMany(w => w.CheckingMedicines).HasForeignKey(h => h.FrequencyId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(h => h.Medicine).WithMany(w => w.CheckingMedicines).HasForeignKey(h => h.MedicineId);
            entityBuilder.HasOne(h => h.Checking).WithMany(w => w.CheckingMedicines).HasForeignKey(h => h.CheckingId);

        }
    }
}
