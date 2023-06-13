using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface ICustomerRepository
    {
        Task<Int64> Create(Customer entity);
        Task<Boolean> Update(Customer entity);
        Task<Customer> GetById(int id);
    }
}
