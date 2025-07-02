using Vertroue.HMS.API.Application.Contracts.Persistence;
using Vertroue.HMS.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vertroue.HMS.API.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithProducts()
        {
            var allCategories = await _dbContext.Categories.Include(x => x.Products).ToListAsync();
           
            return allCategories;
        }
    }
}
