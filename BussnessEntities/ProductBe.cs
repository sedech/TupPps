

namespace BussnessEntities
{
    public class ProductBe:EntityBaseBe
    {

        public int ProviderId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float PriceSales { get; set; }
        public float PricePurchase { get; set; }

        public ProviderBe? Provider { get; set; }
        public CategoryBe? Category { get; set; } 
        

        public List<HistoryPriceBe>? HistoryPrices { get; set;}
    }
}
