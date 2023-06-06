namespace BussnessEntities
{

    public class OrderItemBe:EntityBaseBe
    {   
        public Int64 ProductId { get; set; }
        public Int64 OrderId { get; set; }
        public int Quantity { get; set; }

        public OrderBe Order { get; set; }
        public ProductBe Product { get; set; }
        

    }  
}
