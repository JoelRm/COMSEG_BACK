using Comseg.DataAccess.Interfaces;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Microsoft.EntityFrameworkCore;

namespace Comseg.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ComsegDbContext _context;
        public UserRepository(ComsegDbContext context)
        {
            _context = context; 
        }

        public async Task<LoginInfo?> Login(string UserLogin, string Password)
        {
            var lst = await (from U in _context.Set<User>()
                               .Where(p => p.UserLogin.Equals(UserLogin) && p.Password.Equals(Password))
                             join R in _context.Set<Role>()
                                       on U.RoleId equals R.RoleId
                             select new LoginInfo
                             {
                                 UserId = U.UserId,
                                 UserName = U.UserName,
                                 RoleId = U.RoleId
                             })
                            .SingleOrDefaultAsync();

            return lst;
        }

    }
}
