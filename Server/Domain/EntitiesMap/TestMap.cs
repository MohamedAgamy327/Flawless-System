using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class TestMap
    {
        public TestMap(EntityTypeBuilder<Test> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
