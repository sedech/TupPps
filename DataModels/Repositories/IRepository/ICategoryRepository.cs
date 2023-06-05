using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface ICategoryRepository
    {
        Task<Int64> Create(Category entity);
        Task<Boolean> Update(Category entity);
        Task<Boolean> Delete(int Id);
        Task<IEnumerable<Category>> GetAll(int state, string name);
        Task<Category> GetById(string id);
    }
}
