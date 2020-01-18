using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class CheckingTestMap
    {
        public CheckingTestMap(EntityTypeBuilder<CheckingTest> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.TestId, t.CheckingId });
            entityBuilder.HasOne(h => h.Test).WithMany(w => w.CheckingTests).HasForeignKey(h => h.TestId);
            entityBuilder.HasOne(h => h.Checking).WithMany(w => w.CheckingTests).HasForeignKey(h => h.CheckingId);
        }
    }
}
