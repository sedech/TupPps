namespace BussnessEntities
{
    public class ProviderBe:EntityBaseBe
    {
        public int CUIT { get; set; }
        public string BusnessName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public String WebSite { get; set; }

        public List<ProductBe> Products { get; set;}
       

       
    }
}
