namespace BussnessEntities
{
    public class OrderBe:EntityBaseBe
    {
        
        public Int64 CustomerId { get; set; }
        public Int64 AccountId { get; set; }
        public float Total { get; set; }

        public CustomerBe Customer { get; set; }
        public AccountBe Account { get; set; }

        public List<OrderItemBe> Items { get; set; }

       
    }
}
