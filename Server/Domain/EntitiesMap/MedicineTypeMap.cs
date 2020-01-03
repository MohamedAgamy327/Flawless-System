using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class MedicineTypeMap
    {
        public MedicineTypeMap(EntityTypeBuilder<MedicineType> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }

}
