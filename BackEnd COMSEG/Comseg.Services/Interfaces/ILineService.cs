using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface ILineService
    {

        Task<BaseResponseEntity<ICollection<LineInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<LineInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoLine request, string User);
        Task<BaseResponse> UpdateAsync(int id, DtoLine request, string User);
        Task<BaseResponse> DeleteAsync(int id);

    }
}
