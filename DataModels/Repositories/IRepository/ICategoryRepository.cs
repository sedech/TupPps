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
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetAll(int id);

    }
}



