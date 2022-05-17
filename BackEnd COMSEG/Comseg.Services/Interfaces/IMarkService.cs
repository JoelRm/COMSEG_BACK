using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface IMarkService
    {
        Task<BaseResponseEntity<ICollection<MarkInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<MarkInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoMark request, string User);
        Task<BaseResponse> UpdateAsync(int id, DtoMark request, string User);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
