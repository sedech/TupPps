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
    public class BrandRepository : IBrandRepository
    {
        private readonly FerreTechContext _context;

        public BrandRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64> Create(Brand entity)
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

        public async Task<IEnumerable<Brand>> GetAll(int State, string Name)
        {
            var entities = _context.Brands.Where(u => u.State == State && (u.Name == Name || string.IsNullOrEmpty(Name)));
            return entities;
        }

        public async Task<Brand> GetById(int id)
        {
            try
            {
                var entity = await _context.Brands.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<bool> Update(Brand entity)
        {
            var bran = await _context.Brands.FindAsync(entity.Id);
            if (bran==null)
                throw new Exception("No se pudo actualizar la marca");
            
            bran.Name = entity.Name;
            bran.Logo = entity.Logo;

            return true;
        }
    }
}
