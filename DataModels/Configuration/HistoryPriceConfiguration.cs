using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Configuration
{
    public class HistoryPriceConfiguration
    {
        public HistoryPriceConfiguration(EntityTypeBuilder<HistoryPrice>entityBuilder) 
        {
            entityBuilder.HasKey(u=> u.Id);
            entityBuilder.Property(u => u.ProductId).IsRequired();
            entityBuilder.Property(u => u.Price).IsRequired();

        }
    }
}
