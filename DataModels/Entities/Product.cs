

namespace DataModels.Entities
{
    public class Product:EntityBase
    {

        public int IdProvider { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float PriceSales { get; set; }
        public float PricePurchase { get; set; }

        public Provider Provider { get; set; }
        public Category Category { get; set; } 
        

        public List<HistoryPrice> HistoryPrices { get; set;}
    }
}
