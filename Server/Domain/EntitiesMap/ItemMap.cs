using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class ItemMap
    {
        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Price).IsRequired();
            entityBuilder.Property(t => t.Quantity).IsRequired().HasDefaultValue(0);
            entityBuilder.Property(t => t.Cost).IsRequired().HasDefaultValue(0);
        }
    }
}