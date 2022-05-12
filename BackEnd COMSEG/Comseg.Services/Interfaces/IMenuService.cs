
using Comseg.DTO.Request.Menu;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface IMenuService
    {
        Task<BaseResponseEntity<ICollection<MenuInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<MenuInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoMenu request, string user);
        Task<BaseResponse> UpdateAsync(int id, DtoMenu request, string user);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
