

namespace DataModels.Entities
{
    public class HistoryPrice:EntityBase
    {
        public Int64 IdProduct { get; set; }    
        public float Price { get; set; }
        public Product Product { get; set; }
      
    }
}
