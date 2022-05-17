using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCollectionAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<ICollection<CategoryInfo?>> GetCategoryInfoCollectionAsync();
        Task<CategoryInfo?> GetCategoryInfoByIdAsync(int id);
        Task<int> CreateAsync(Category entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
