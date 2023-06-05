namespace DataModels.Entities
{
    public class Order:EntityBase
    {
        
        public Int64 IdCustomer { get; set; }
        public Int64 IdAccount { get; set; }
        public float Total { get; set; }

        public Customer Customer { get; set; }
        public Account Account { get; set; }

        public List<OrderItem> Items { get; set; }

       
    }
}
