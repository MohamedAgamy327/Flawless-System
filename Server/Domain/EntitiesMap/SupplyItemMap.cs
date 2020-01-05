using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class SupplyItemMap
    {
        public SupplyItemMap(EntityTypeBuilder<SupplyItem> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.ItemId, t.SupplyId });
            entityBuilder.HasOne(h => h.Item).WithMany(w => w.SupplyItems).HasForeignKey(h => h.ItemId);
            entityBuilder.HasOne(h => h.Supply).WithMany(w => w.SupplyItems).HasForeignKey(h => h.SupplyId);
        }
    }
}
