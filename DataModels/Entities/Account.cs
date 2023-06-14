
namespace DataModels.Entities
{
    public class Account:EntityBase
    {
      
        public Int64 RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
        

       
    }
}
