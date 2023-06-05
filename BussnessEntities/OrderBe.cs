namespace BussnessEntities
{
    public class OrderBe:EntityBaseBe
    {
        
        public Int64 IdCustomer { get; set; }
        public Int64 IdAccount { get; set; }
        public float Total { get; set; }

        public CustomerBe Customer { get; set; }
        public AccountBe Account { get; set; }

        public List<OrderItemBe> Items { get; set; }

       
    }
}
