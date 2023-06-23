using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<Account>entityBuilder) 
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.LastName).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Email).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Password).IsRequired().HasMaxLength(250);
          
        }
    }
}


