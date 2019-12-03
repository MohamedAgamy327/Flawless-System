using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Username).IsRequired();
            entityBuilder.Property(t => t.Role).IsRequired();
            entityBuilder.Property(t => t.PasswordHash).IsRequired();
            entityBuilder.Property(t => t.PasswordSalt).IsRequired();
            entityBuilder.Property(t => t.IsTerminated).HasDefaultValue(false);
        }
    }
}
