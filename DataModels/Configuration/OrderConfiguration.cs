using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataModels.Configuration
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Total).IsRequired();
            entityBuilder.Property(u => u.UserId).IsRequired().HasMaxLength(250); 
            entityBuilder.Property(u => u.OrderItemId).IsRequired();
        }
    }
}


