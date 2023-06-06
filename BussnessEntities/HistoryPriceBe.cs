

namespace BussnessEntities
{
    public class HistoryPriceBe:EntityBaseBe
    {
        public Int64 ProductId { get; set; }    
        public float Price { get; set; }
        public ProductBe Product { get; set; }
      
    }
}
