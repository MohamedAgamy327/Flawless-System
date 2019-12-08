using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class PatientMap
    {
        public PatientMap(EntityTypeBuilder<Patient> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Birthday).IsRequired();
            entityBuilder.Property(t => t.Gender).IsRequired();
            entityBuilder.Property(t => t.Telephone).IsRequired();
        }
    }
}
