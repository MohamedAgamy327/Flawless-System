using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class WaitingMap
    {
        public WaitingMap(EntityTypeBuilder<Waiting> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ArrivalDate).HasDefaultValueSql("getdate()");
            entityBuilder.HasOne(h => h.Patient).WithMany(w => w.Waitings).HasForeignKey(h => h.PatientId);
        }
    }
}
