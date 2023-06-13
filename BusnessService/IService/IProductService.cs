using BussnessEntities;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface IProductService
    {

        Task<long> Create(ProductBe entity);
        Task<bool> Update(ProductBe entity);
        Task<bool> Delete(int id);
        Task<List<ProductBe>> GetAll(int state, string name);
        Task<ProductBe> GetById(int id);

    }
}
