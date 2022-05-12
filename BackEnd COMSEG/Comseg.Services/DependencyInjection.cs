using Comseg.DataAccess.Implementations;
using Comseg.DataAccess.Interfaces;
using Comseg.Services.Implementations;
using Comseg.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Comseg.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserService, UserService>();

            services.AddTransient<IUnitRepository, UnitRepository>()
                .AddTransient<IUnitService, UnitService>();

            services.AddTransient<IRoleRepository, RoleRepository>()
                .AddTransient<IRoleService, RoleService>();

            services.AddTransient<IMenuRepository, MenuRepository>()
            .AddTransient<IMenuService, MenuService>();

            services.AddTransient<ISubMenuRepository, SubMenuRepository>()
            .AddTransient<ISubMenuService, SubMenuService>();

            services.AddTransient<IPageService, PageService>();
            //.AddTransient<IUnitService, UnitService>();

            services.AddTransient<IBranchRepository, BranchRepository>()
            .AddTransient<IBranchService, BranchService>();

            return services;
        }
    }
}
