using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class CheckingItemMap
    {
        public CheckingItemMap(EntityTypeBuilder<CheckingItem> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.ItemId, t.CheckingId });
            entityBuilder.HasOne(h => h.Item).WithMany(w => w.CheckingItems).HasForeignKey(h => h.ItemId);
            entityBuilder.HasOne(h => h.Checking).WithMany(w => w.CheckingItems).HasForeignKey(h => h.CheckingId);
        }
    }
}
