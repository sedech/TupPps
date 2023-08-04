using BussnessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface IOrderItemService
    {
        Task<long> Create(OrderItemBe entity);
        Task<bool> Update(OrderItemBe entity);
        Task<bool> Delete(int id);
        Task<OrderItemBe> GetById(int id);
        Task<IEnumerable<OrderItemBe>> GetAll();
        
    }
}
