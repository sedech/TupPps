using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface IOrderRepository
    {
        Task<Int64> Create(Order entity);
        Task<Boolean> Update(Order entity);
        Task<Boolean> Delete(int id);
        Task<Order> GetById(int id);
        Task<IEnumerable<Order>> GetAll(int id);

    }
}
