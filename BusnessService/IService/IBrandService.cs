using BussnessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface IBrandService
    {
        Task<long> Create(BrandToCreateBe entity);
        Task<bool> Update(BrandBe entity);
        Task<List<BrandBe>> GetAll(int state, string name);
        Task<BrandBe> GetById(int id);
    }
}
