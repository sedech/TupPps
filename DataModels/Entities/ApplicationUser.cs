using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Int64 RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
