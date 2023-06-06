using DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataModels.Configuration
{
    public class OrderItemConfiguration
    {
        public OrderItemConfiguration(EntityTypeBuilder<OrderItem>entityBuilder) 
        {
          entityBuilder.HasKey(u=>u.Id);
          entityBuilder.Property(u => u.ProductId).IsRequired();
          entityBuilder.Property(u => u.OrderId).IsRequired();
          entityBuilder.Property(u => u.Quantity).IsRequired();
        }
    }
}
