namespace DataModels.Entities
{
    public class Provider:EntityBase
    {
        public int CUIT { get; set; }
        public string BusnessName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public String WebSite { get; set; }

        public List<Product> Products { get; set;}
       

       
    }
}
