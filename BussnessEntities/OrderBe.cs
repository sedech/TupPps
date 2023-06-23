namespace BussnessEntities
{
    public class OrderBe:EntityBaseBe
    {
        
        
        public Int64 AccountId { get; set; }
        public float Total { get; set; }

      
        public AccountBe Account { get; set; }

        public List<OrderItemBe> Items { get; set; }

       
    }
}
