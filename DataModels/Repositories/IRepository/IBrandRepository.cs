using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface IBrandRepository
    {
            Task<Int64> Create(Brand entity);
            Task<Boolean> Update(Brand entity);
            Task<Brand> GetById(int id);
            Task<IEnumerable<Brand>> GetAll(int state, string name);
    }
}
