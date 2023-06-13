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
    public class ProviderService : IProviderService
    {
           private readonly IProviderRepository _repo;
           private readonly IMapper _maapper;

        public ProviderService(IProviderRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public async Task<Int64> Create(ProviderBe entity)
        {
            var result = _maapper.Map<Provider>(entity);
            return await _repo.Create(result);
        }

        public async Task<ProviderBe> GetById(int id)
        {
            return _maapper.Map<ProviderBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(ProviderBe entity)
        {
            var result = _maapper.Map<Provider>(entity);
            return await _repo.Update(result);

        }
    }
}
