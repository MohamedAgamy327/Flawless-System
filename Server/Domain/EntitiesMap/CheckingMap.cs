using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class CheckingMap
    {
        public CheckingMap(EntityTypeBuilder<Checking> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.HasOne(h => h.Patient).WithMany(w => w.Checkings).HasForeignKey(h => h.PatientId);
        }
    }
}
