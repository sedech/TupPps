using DataModels.Context;
using DataModels.Entities;
using DataModels.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Repositories.Repository

{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FerreTechContext _context;
        public CategoryRepository(FerreTechContext context)
        {
            _context = context;
        }
        public async Task<Int64> Create(Category entity)
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

        public async Task<IEnumerable<Category>> GetAll(int State, string Name)
        {
            var entities = _context.Categories.Where(u => u.State == State && (u.Name == Name || string.IsNullOrEmpty(Name)));
            return entities;
        }

        public async Task<Category> GetById(int id)
        {
            try
            {
                var entity = await _context.Categories.SingleOrDefaultAsync(u => u.Id == id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> Update(Category entity)
        {
            var cate = await _context.Categories.FindAsync(entity.Id);
            if (cate == null)
                throw new Exception("No se pudo actualizar la categoria");

            cate.Name = entity.Name;
            cate.Description = entity.Description;
       
            return true;
        }



    }
}