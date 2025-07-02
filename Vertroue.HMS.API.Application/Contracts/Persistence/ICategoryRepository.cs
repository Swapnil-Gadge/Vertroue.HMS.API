using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithProducts();
    }
}
