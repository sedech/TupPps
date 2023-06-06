

namespace BussnessEntities
{
    public class CustomerBe:EntityBaseBe
    {
        public Int64 AccountId { get; set; }    
        public int CUIT { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        public AccountBe Account { get; set; }

    }
}
