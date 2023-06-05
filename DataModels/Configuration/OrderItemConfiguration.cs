using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataModels.Configuration
{
    public class OrderItemConfiguration
    {
        public OrderItemConfiguration(EntityTypeBuilder<OrderItem>entityBuilder) 
        {
          entityBuilder.HasKey(u=>u.Id);
          entityBuilder.Property(u => u.IdProduct).IsRequired();
          entityBuilder.Property(u => u.IdOrder).IsRequired();
          entityBuilder.Property(u => u.Quantity).IsRequired();
        }
    }
}
