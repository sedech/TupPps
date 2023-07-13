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

        Task<long> Create(ProductToCreateBe entity);
        Task<bool> Update(ProductBe entity);
        Task<bool> Delete(int id);
        Task<ProductBe> GetById(int id);
        Task<IEnumerable<ProductBe>> GetAll(int id);
    }   
}    


