



namespace DataModels.Entities
{
    public class Product:EntityBase
    {
        

        public Int64 ProviderId { get; set; }
        public Int64 CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public float? PriceSales { get; set; }
        public float? PricePurchase { get; set; }
        public string? Img { get; set; }
        public string? Brand { get; set; }

        public Provider? Provider { get; set; }
        public Category? Category { get; set; } 
        

        public List<HistoryPrice>? HistoryPrices { get; set;}
    }
}
