
namespace BussnessEntities


{
    public class AccountBe:EntityBaseBe
    {
      
        public Int64 RoleId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RoleBe Role { get; set; }
        

       
    }
}
