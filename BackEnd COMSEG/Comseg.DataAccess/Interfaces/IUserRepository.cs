using Comseg.Entities.Complex;

namespace Comseg.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<LoginInfo?> Login(string UserLogin, string Password);
    }
}
