using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface IAccountRepository
    {
        Task<Int64> Create(Account entity);
        Task<Boolean> Update(Account entity);
        Task<Account> GetById(int id);
        Task<Account> Login(string UserName, string Password);
    }
}
