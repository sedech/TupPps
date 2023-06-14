namespace BussnessEntities
{
    public class BrandBe:EntityBaseBe
    {
        public string Name { get; set; }
        public string Logo { get; set; }

        public List<ProductBe> Products { get; set; }
    }
}
