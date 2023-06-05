using DataModels.Entities;

namespace DataModels.Entities
{
    public class Customer:EntityBase
    {
        //public Int64 IdAccount { get; set; }    
        public int CUIT { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        //public Account Account { get; set; }
        public List<Order> Orders { get; set;}

    }
}
