using BussnessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface IOrderService
    {
        Task<long> Create(OrderBe entity);
        Task<bool> Update(OrderBe entity);
        Task<bool> Delete(int id);
        Task<OrderBe> GetById(int id);
        Task<IEnumerable<OrderBe>> GetAll();
      

    }
}
