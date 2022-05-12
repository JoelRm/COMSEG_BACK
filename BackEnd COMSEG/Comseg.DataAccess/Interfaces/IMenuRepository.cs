using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface IMenuRepository
    {
        Task<ICollection<Menu>> GetCollectionAsync();
        Task<Menu?> GetByIdAsync(int id);
        Task<ICollection<MenuInfo?>> GetMenuInfoCollectionAsync();
        Task<MenuInfo?> GetMenuInfoByIdAsync(int id);
        Task<int> CreateAsync(Menu entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
