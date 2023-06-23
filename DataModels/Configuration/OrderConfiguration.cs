using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Order>entityBuilder) 
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.AccountId).IsRequired();
            entityBuilder.Property(u => u.Total).IsRequired();

            entityBuilder.HasMany(u=>u.OrderItems).WithOne(u => u.Order).HasForeignKey(u => u.OrderId).IsRequired();
        }
    }
}
