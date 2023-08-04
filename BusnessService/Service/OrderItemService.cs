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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repo;
        private readonly IMapper _maapper;

        public OrderItemService(IOrderItemRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }


        public async Task<Int64> Create(OrderItemBe entity)
        {
            var result = _maapper.Map<OrderItem>(entity);
            return await _repo.Create(result);

        }

        public Task<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<OrderItemBe> GetById(int id)
        {
            return _maapper.Map<OrderItemBe>(await _repo.GetById(id));
        }

        public async Task<bool> Update(OrderItemBe entity)
        {
            var result = _maapper.Map<OrderItem>(entity);
            return await _repo.Update(result);

        }

        public async Task<IEnumerable<OrderItemBe>> GetAll()
        {
            var orderItems = await _repo.GetAll();
            return _maapper.Map<IEnumerable<OrderItemBe>>(orderItems);
        }

    }
}
