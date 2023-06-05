using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface IProductRepository
    {
        Task<Int64> Create(Product entity);
        Task<Boolean> Update(Product entity);
        Task<Boolean> Delete(int id);
        Task<IEnumerable<Product>> GetAll(int state, string name);
        Task<Product> GetById(int id);
    }
}
