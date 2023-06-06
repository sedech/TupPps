namespace DataModels.Entities
{
    public class Order:EntityBase
    {
        
        public Int64 CustomerId { get; set; }
        public Int64 AccountId { get; set; }
        public float Total { get; set; }

        public Customer Customer { get; set; }
        public Account Account { get; set; }

        public List<OrderItem> Items { get; set; }

       
    }
}
