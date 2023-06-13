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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _maapper;

        public CustomerService(ICustomerRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public async Task<Int64> Create(CustomerBe entity)
        {
            var result = _maapper.Map<Customer>(entity);
            return await _repo.Create(result);
        }

        public async Task<CustomerBe> GetById(int id)
        {
            return _maapper.Map<CustomerBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(CustomerBe entity)
        {
            var result = _maapper.Map<Customer>(entity);
            return await _repo.Update(result);

        }
    }
}
