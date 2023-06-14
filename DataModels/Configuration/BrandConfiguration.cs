using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class BrandConfiguration
    {
        public BrandConfiguration(EntityTypeBuilder<Brand>entityBuilder) 
        {
            entityBuilder.HasKey(u=>u.Id);
            entityBuilder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Logo).IsRequired().HasMaxLength(250);
           

            entityBuilder.HasMany(u=>u.Products).WithOne(u=>u.Brand).HasForeignKey(u=>u.BrandId).IsRequired();
        }
    }
}
