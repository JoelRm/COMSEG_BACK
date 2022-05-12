using Comseg.DTO.Request;
using Comseg.DTO.Response;

namespace Comseg.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponseLogin<UserLoginResponse>> Login(DtoLogin request);
    }
}
