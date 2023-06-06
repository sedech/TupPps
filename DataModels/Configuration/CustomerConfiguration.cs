using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<Customer>entityBuilder) 
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u=> u.CUIT).IsRequired().HasMaxLength(20);
            entityBuilder.Property(u => u.FirstName).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.LastName).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Phone).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Adress).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Email).IsRequired().HasMaxLength(250);


            entityBuilder.HasMany(u => u.Orders).WithOne(u => u.Customer).HasForeignKey(u => u.CustomerId).IsRequired();
        }
    }
}
