using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface IUnitRepository
    {
        Task<ICollection<Unit>> GetCollectionAsync();
        Task<Unit?> GetByIdAsync(int id);
        Task<ICollection<UnitInfo?>> GetUnitInfoCollectionAsync();
        Task<UnitInfo?> GetUnitInfoByIdAsync(int id);
        Task<int> CreateAsync(Unit entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
