
using Comseg.DTO.Request.SubMenu;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface ISubMenuService
    {
        Task<BaseResponseEntity<ICollection<SubMenuInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<SubMenuInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoSubMenu request,string user);
        Task<BaseResponse> UpdateAsync(int id, DtoSubMenu request,string user);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
