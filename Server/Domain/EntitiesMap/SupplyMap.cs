using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class SupplyMap
    {
        public SupplyMap(EntityTypeBuilder<Supply> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Notes).IsRequired();
            entityBuilder.Property(t => t.Date).IsRequired().HasColumnType("date").HasDefaultValueSql("getdate()"); ;
        }
    }
}