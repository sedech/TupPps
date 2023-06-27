
namespace DataModels.Entities
{
    public class Category:EntityBase
    {
    
        public string Name { get; set; }
        //public string Description { get; set; }

        public List<Product> Products { get; set; }

        public Category()
        {
            // Inicializar la lista de Products en el constructor
            Products = new List<Product>();
        }

    }
}
