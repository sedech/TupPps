namespace DataModels.Entities
{
    public class Brand:EntityBase
    {
        public string Name { get; set; }
        public string Logo { get; set; }

        public List<Product> Products { get; set; }

    }
}
