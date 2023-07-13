using BussnessEntities;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.IService
{
    public interface ICategoryService
    {
        Task<long> Create(CategoryToCreateBe entity);
        Task<bool> Update(CategoryBe entity);
        Task<CategoryBe> GetById(int id);
 
    }
}
   
    