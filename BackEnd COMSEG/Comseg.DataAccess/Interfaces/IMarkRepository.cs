using Comseg.Entities;
using Comseg.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comseg.DataAccess.Interfaces
{
    public interface IMarkRepository
    {
        Task<ICollection<Mark>> GetCollectionAsync();
        Task<Mark?> GetByIdAsync(int id);
        Task<ICollection<MarkInfo?>> GetMarkInfoCollectionAsync();
        Task<MarkInfo?> GetMarkInfoByIdAsync(int id);
        Task<int> CreateAsync(Mark entity);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
