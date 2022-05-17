using Comseg.Entities;
using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface ILineRepository
    {
        Task<ICollection<Line>> GetCollectionAsync();

        Task<Line?> GetByIdAsync(int id);

        Task<ICollection<LineInfo?>> GetLineInfoCollectionAsync();

        Task<LineInfo?> GetLineInfoByIdAsync(int id);

        Task<int> CreateAsync(Line Entity);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
