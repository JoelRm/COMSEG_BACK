using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseResponseEntity<ICollection<CategoryInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<CategoryInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoCategory request, string User);
        Task<BaseResponse> UpdateAsync(int id, DtoCategory request, string User);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
