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
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _maapper;

        public OrderService(IOrderRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public async Task<Int64> Create(OrderBe entity)
        {
            var result = _maapper.Map<Order>(entity);
            return await _repo.Create(result);

        }

        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<OrderBe> GetById(int id)
        {
            return _maapper.Map<OrderBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(OrderBe entity)
        {
            var result = _maapper.Map<Order>(entity);
            return await _repo.Update(result);

        }

    }
}
