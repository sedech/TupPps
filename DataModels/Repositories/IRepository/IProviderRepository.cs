using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.IRepository
{
    public interface IProviderRepository
    {
            Task<Int64> Create(Provider entity);
            Task<Boolean> Update(Provider entity);
            Task<Provider> GetById(int id);
    }
}
