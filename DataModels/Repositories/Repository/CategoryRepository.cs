using DataModels.Context;
using DataModels.Entities;
using DataModels.Repositories.IRepository;

namespace DataModels.Repositories.Repository

{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FerreTechContext _context;
        public CategoryRepository(FerreTechContext context)
        {
            _context = context;
        }
        public Task<Int64> Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll(int state, string name)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
