using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface IOrderItemRepository
    {
        Task<Int64> Create(OrderItem entity);
        Task<Boolean> Update(OrderItem entity);
        Task<Boolean> Delete(int id);
        Task<OrderItem> GetById(int id);
        Task<IEnumerable<OrderItem>> GetAll();
        Task<IEnumerable<OrderItem>> GetByOrderId(int OrderId);


    }
}

