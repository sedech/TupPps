using DataModels.Context;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FerreTechContext _context;
        public OrderRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64> Create(Order entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.State = 1;

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.Orders.SingleOrDefaultAsync(u => u.Id == id);
                if (entity == null)
                    throw new Exception("No existe el order para ese id");

                _context.Orders.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Order> GetById(int id)
        {
            try
            {
                var entity = await _context.Orders.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> Update(Order entity)
        {
            var ord = await _context.Orders.FindAsync(entity.Id);
            if (ord == null)
                throw new Exception("No se pudo actualizar este order");
            ord.UserId = entity.Id.ToString(); ;
            ord.Total = entity.Total;

            return true;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var entities = await _context.Orders.ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(int OrderId)
        {
            return await _context.OrderItems.Where(item => item.OrderId == OrderId).ToListAsync();
        }
    }
}
