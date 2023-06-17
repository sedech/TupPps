using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels.Entities
{
    public class Order:EntityBase
    {
        
        public Int64 CustomerId { get; set; }
        public Int64 AccountId { get; set; }
        public float Total { get; set; }

        [ForeignKey(nameof(CustomerId))] 
        
        public Account Account { get; set; }

        public List<OrderItem> OrderItems { get; set; }

       
    }
}
