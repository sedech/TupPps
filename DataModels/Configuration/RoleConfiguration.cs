using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role>entityBuilder) 
        {
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            entityBuilder.Property(u => u.Description).HasMaxLength(350);

            entityBuilder.HasData(
                new Role() {
                    Id=1,
                    Name="Admin",
                    Description="Tiene acceso a todos"
                },
                new Role()
                {
                    Id=2,
                    Name = "Vendedor",
                    Description = "Tiene acceso ilimitado"
                },
                new Role()
                {
                    Id=3,
                    Name = "Cliente",
                    Description = "Tiene acceso a compras"
                }

                );
            entityBuilder.HasMany(p=>p.Accounts).WithOne(p=>p.Role).HasForeignKey(p=>p.RoleId).IsRequired();

        }
    }
}
