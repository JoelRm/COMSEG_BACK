
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface IUnitService
    {
        Task<BaseResponseEntity<ICollection<UnitInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<UnitInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoUnit request,string User);
        Task<BaseResponse> UpdateAsync(int id, DtoUnit request,string User);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
