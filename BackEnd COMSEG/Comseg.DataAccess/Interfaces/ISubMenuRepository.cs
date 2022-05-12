using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface ISubMenuRepository
    {
        Task<ICollection<SubMenu>> GetCollectionAsync();
        Task<SubMenu?> GetByIdAsync(int id);
        Task<ICollection<SubMenuInfo?>> GetSubMenuInfoCollectionAsync();
        Task<SubMenuInfo?> GetSubMenuInfoByIdAsync(int id);
        Task<int> CreateAsync(SubMenu entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
