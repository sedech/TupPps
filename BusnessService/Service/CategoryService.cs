using AutoMapper;
using BusnessService.IService;
using BussnessEntities;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.Service
{
    public class CategoryService : ICategoryService
    {
      private readonly ICategoryRepository _repo;
      private readonly IMapper _maapper;

      public CategoryService(ICategoryRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public async Task<Int64> Create(CategoryToCreateBe entity)
        {
            var result = _maapper.Map<Category>(entity);
            return await _repo.Create(result);
        }

        public async Task<CategoryBe> GetById(int id)
        {
            return _maapper.Map<CategoryBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(CategoryBe entity)
        {
            var result = _maapper.Map<Category>(entity);
            return await _repo.Update(result);

        }
    }
}
