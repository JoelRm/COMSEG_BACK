using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetCollectionAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<ICollection<RoleInfo?>> GetRoleInfoCollectionAsync();
        Task<RoleInfo?> GetRoleInfoByIdAsync(int id);
        Task<int> CreateAsync(Role entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
