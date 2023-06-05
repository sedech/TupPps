using BussnessEntities;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.Service
{
    public interface IProductService
    {
      
        Task<Int64> Create(ProductBe entity);
        Task<Boolean> Update(ProductBe entity);
        Task<Boolean> Delete(int id);
        Task<List<ProductBe>> GetAll(int state, string name);
        Task<ProductBe> GetById(int id);

    }
}
