using Comseg.Entities;
using Comseg.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comseg.DataAccess.Interfaces
{
    public interface IFamilyRepository
    {
        Task<ICollection<Family>> GetCollectionAsync();

        Task<Family?> GetByIdAsync(int id);

        Task<ICollection<FamilyInfo?>> GetFamilyInfoCollectionAsync();

        Task<FamilyInfo?> GetFamilyInfoByIdAsync(int id);

        Task<int> CreateAsync(Family Entity);

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
