
using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface IBranchRepository
    {
        Task<ICollection<Branch>> GetCollectionAsync();
        Task<Branch?> GetByIdAsync(int id);
        Task<ICollection<BranchInfo?>> GetBranchInfoCollectionAsync();
        Task<BranchInfo?> GetBranchInfoByIdAsync(int id);
        Task<int> CreateAsync(Branch entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
