

namespace DataModels.Entities
{
    public class HistoryPrice:EntityBase
    {
        public Int64 ProductId { get; set; }    
        public float Price { get; set; }
        public Product Product { get; set; }
      
    }
}
