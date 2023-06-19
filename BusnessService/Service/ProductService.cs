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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _maapper;
        public ProductService(IProductRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public async Task<Int64> Create(ProductToCreateBe entity)
        {
            var result = _maapper.Map<Product>(entity);
            return await _repo.Create(result);

        }

        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<List<ProductBe>> GetAll(int state, string name)
        {
            var entities = await _repo.GetAll(state, name);
            return  _maapper.Map<List<ProductBe>>(entities);
        }

        public async Task<ProductBe> GetById(int id)
        {
            return  _maapper.Map<ProductBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(ProductBe entity)
        {
            var result = _maapper.Map<Product>(entity);
            return await _repo.Update(result);

        }
    }
}
