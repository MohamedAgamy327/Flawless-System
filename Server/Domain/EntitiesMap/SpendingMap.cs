﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class SpendingMap
    {
        public SpendingMap(EntityTypeBuilder<Spending> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.statement).IsRequired();
            entityBuilder.Property(t => t.Date).HasDefaultValueSql("getdate()");
        }
    }
}
