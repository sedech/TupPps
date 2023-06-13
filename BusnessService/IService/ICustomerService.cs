using BussnessEntities;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface ICustomerService
    {
        Task<long> Create(CustomerBe entity);
        Task<bool> Update(CustomerBe entity);
        Task<CustomerBe> GetById(int id);
    }
}
