using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface IFamilyService
    {
        Task<BaseResponseEntity<ICollection<FamilyInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<FamilyInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoFamily request, string User);
        Task<BaseResponse> UpdateAsync(int id, DtoFamily request, string User);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
