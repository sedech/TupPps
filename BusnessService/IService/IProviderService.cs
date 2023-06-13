using BussnessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface IProviderService
    {
        Task<long> Create(ProviderBe entity);
        Task<bool> Update(ProviderBe entity);
        Task<ProviderBe> GetById(int id);
    }
}
