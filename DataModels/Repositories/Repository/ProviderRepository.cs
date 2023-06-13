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
    public class ProviderRepository : IProviderRepository
    {
        private readonly FerreTechContext _context;

        public ProviderRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64> Create(Provider entity)
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

        public async Task<Provider> GetById(int id)
        {
            try
            {
                var entity = await _context.Providers.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<bool> Update(Provider entity)
        {
            var provi = await _context.Providers.FindAsync(entity.Id);
            if (provi==null)
                throw new Exception("No se pudo actualizar el proveedor");
            provi.CUIT = entity.CUIT;
            provi.BusnessName = entity.BusnessName;
            provi.Address = entity.Address;
            provi.Email = entity.Email;
            provi.WebSite = entity.WebSite;

            return true;
        }
    }
}
