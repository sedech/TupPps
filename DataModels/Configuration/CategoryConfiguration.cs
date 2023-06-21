using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<Category>entityBuilder) 
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            //entityBuilder.Property(u => u.Description).HasMaxLength(450);

            entityBuilder.HasMany(u=> u.Products).WithOne(u => u.Category).HasForeignKey(u=>u.CategoryId).IsRequired();
        }
    }
}
