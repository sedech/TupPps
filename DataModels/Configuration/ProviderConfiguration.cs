using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class ProviderConfiguration
    {
        public ProviderConfiguration(EntityTypeBuilder<Provider>entityBuilder) 
        {
            entityBuilder.HasKey(u=>u.Id);
            entityBuilder.Property(u => u.CUIT).IsRequired();
            entityBuilder.Property(u => u.BusnessName).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Address).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Email).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.WebSite).IsRequired().HasMaxLength(250);

            entityBuilder.HasMany(u=>u.Products).WithOne(u=>u.Provider).HasForeignKey(u=>u.ProviderId).IsRequired();
        }
    }
}
