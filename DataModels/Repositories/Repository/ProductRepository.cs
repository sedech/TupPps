﻿using DataModels.Context;
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
    public class ProductRepository : IProductRepository
    {
        private readonly FerreTechContext _context;

        public ProductRepository(FerreTechContext context)
        {
            _context = context;
        }

        public async Task<Int64> Create(Product entity)
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
                var entity = await _context.Products.SingleOrDefaultAsync(u => u.Id == id);
                if (entity == null)
                    throw new Exception("No existe producto para ese id");

                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var entities = await _context.Products.ToListAsync();
            return entities;
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var entity = await _context.Products.SingleOrDefaultAsync(u => u.Id == id);
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Update(Product entity)
        {
            var prod = await _context.Products.FindAsync(entity.Id);
            if (prod == null)
                throw new Exception("No se pudo actualizar este producto");

            prod.Name = entity.Name;
            prod.PricePurchase = entity.PricePurchase;
            prod.Description = entity.Description;
            prod.Stock = entity.Stock;
            prod.PriceSales = entity.PriceSales;
            prod.Img = entity.Img;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
