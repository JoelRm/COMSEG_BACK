using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface IBranchService
    {
        Task<BaseResponseEntity<ICollection<BranchInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<BranchInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoBranch request, string User);
        Task<BaseResponse> UpdateAsync(int id, DtoBranch request, string User);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
