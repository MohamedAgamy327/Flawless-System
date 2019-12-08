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
            entityBuilder.Property(t => t.Drop).IsRequired();
            entityBuilder.Property(t => t.Type).IsRequired();
        }
    }
}
