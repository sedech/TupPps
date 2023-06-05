

namespace BussnessEntities
{
    public class RoleBe:EntityBaseBe
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
       
        public List<AccountBe> Accounts { get; set; }

    }
}
