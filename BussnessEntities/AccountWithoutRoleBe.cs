using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnessEntities
{
    public class AccountWithoutRoleBe
    {
        public Int64 RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public int State { get; set; }
    }
}
