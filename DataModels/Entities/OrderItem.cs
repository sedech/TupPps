namespace DataModels.Entities
{

    public class OrderItem:EntityBase
    {   
        public Int64 IdProduct { get; set; }
        public Int64 IdOrder { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        

    }  
}
