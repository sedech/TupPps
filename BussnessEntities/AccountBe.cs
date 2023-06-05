
namespace BussnessEntities


{
    public class AccountBe:EntityBaseBe
    {
      
        public Int64 IdRole { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RoleBe Role { get; set; }
        public List<CustomerBe> Customers { get; set; }

       
    }
}
