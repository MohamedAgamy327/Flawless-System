using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class MedicineMap
    {
        public MedicineMap(EntityTypeBuilder<Medicine> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.HasOne(h => h.MedicineType).WithMany(w => w.Medicines).HasForeignKey(h => h.MedicineTypeId);
            entityBuilder.HasOne(h => h.Frequency).WithMany(w => w.Medicines).HasForeignKey(h => h.FrequencyId);
        }
    }
}
