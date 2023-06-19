using BussnessEntities;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface IAccountService
    {
        Task<long> Create(AccountWithoutRoleBe entity);
        Task<bool> Update(AccountBe entity);
        Task<AccountBe> GetById(int id);
        Task<AccountWithoutRoleWithUsersBe?> Login(string UserName, string Password);
    }
}
