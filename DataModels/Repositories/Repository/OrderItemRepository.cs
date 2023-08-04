using DataModels.Context;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly FerreTechContext _context;
        public OrderItemRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64> Create(OrderItem entity)
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
                var entity = await _context.OrderItems.SingleOrDefaultAsync(u => u.Id == id);
                if (entity == null)
                    throw new Exception("No existe el item para ese id");

                _context.OrderItems.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

      
        public async Task<OrderItem> GetById(int id)
        {
            try
            {
                var entity = await _context.OrderItems.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> Update(OrderItem entity)
        {
            var item = await _context.OrderItems.FindAsync(entity.Id);
            if (item == null)
                throw new Exception("No se pudo actualizar este item");
                item.ProductId = entity.ProductId;
                item.OrderId = entity.OrderId;
                item.Quantity = entity.Quantity;

            return true;
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            var entities = await _context.OrderItems.ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(int OrderId)
        {
            return await _context.OrderItems.Where(item => item.OrderId == OrderId).ToListAsync();
        }


    }
}
