using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product>entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.ProviderId).IsRequired();
            entityBuilder.Property(u => u.CategoryId).IsRequired();
            entityBuilder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Description).HasMaxLength(250);
            entityBuilder.Property(u => u.Stock).IsRequired();
            entityBuilder.Property(u => u.PriceSales).IsRequired();
            entityBuilder.Property(u => u.PricePurchase).IsRequired();

            entityBuilder.HasMany(u => u.HistoryPrices).WithOne(u => u.Product).HasForeignKey(u => u.ProductId).IsRequired();

        }
    }
}
