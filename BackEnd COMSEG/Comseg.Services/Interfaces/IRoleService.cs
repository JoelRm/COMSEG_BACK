using Comseg.DTO.Request.Role;
using Comseg.DTO.Response;
using Comseg.Entities.Complex;

namespace Comseg.Services.Interfaces
{
    public interface IRoleService
    {
        Task<BaseResponseEntity<ICollection<RoleInfo?>>> GetCollectionAsync();
        Task<BaseResponseEntity<RoleInfo?>> GetByIdAsync(int id);
        Task<BaseResponseEntity<int>> CreateAsync(DtoRole request, string user);
        Task<BaseResponse> UpdateAsync(int id, DtoRole request, string user);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
