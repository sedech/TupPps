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
    public class CustomerRepository:ICustomerRepository
    {
        private readonly FerreTechContext _context;

        public CustomerRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64>  Create(Customer entity)
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

        public async Task<Customer> GetById(int id)
        {
            try
            {
                var entity = await _context.Customers.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<bool> Update(Customer entity)
        {
            var custo = await _context.Customers.FindAsync(entity.Id);
            if (custo == null)
                throw new Exception("No se pudo actualizar el cliente");
            custo.CUIT = entity.CUIT;
            custo.FirstName = entity.FirstName;
            custo.LastName = entity.LastName;
            custo.Phone = entity.Phone;
            custo.Adress = entity.Adress;
            custo.Email = entity.Email;

            return true;
        }

    }
}
