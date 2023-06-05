
namespace BussnessEntities
{
    public class CategoryBe:EntityBaseBe
    {
    
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProductBe> Products { get; set; }

    }
}
