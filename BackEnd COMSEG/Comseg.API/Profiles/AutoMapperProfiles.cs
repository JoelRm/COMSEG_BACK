using AutoMapper;
using Comseg.DTO.Request;
using Comseg.DTO.Request.Menu;
using Comseg.DTO.Request.Role;
using Comseg.DTO.Request.SubMenu;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;


namespace Comseg.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LoginInfo, UserLoginResponse>();

            CreateMap<Unit, UnitInfo>();
            CreateMap<UnitInfo, Unit>();
            CreateMap<DtoUnit, Unit>();
            

            CreateMap<Role, RoleInfo>();
            CreateMap<RoleInfo, Role>();
            CreateMap<DtoRole, Role>();
            

            CreateMap<Menu, MenuInfo>();
            CreateMap<MenuInfo, Menu>();
            CreateMap<DtoMenu, Menu>();
            CreateMap<Menu, MenuResponse>();

            CreateMap<SubMenu, SubMenuInfo>();
            CreateMap<SubMenu, SubMenuResponse>();
            CreateMap<SubMenuInfo, SubMenu>();
            CreateMap<DtoSubMenu, SubMenu>();

            CreateMap<Branch, BranchInfo>();
            CreateMap<BranchInfo, Branch>();
            CreateMap<DtoBranch, Branch>();

            CreateMap<Line, LineInfo>();
            CreateMap<LineInfo, Line>();
            CreateMap<DtoLine, Line>();

            CreateMap<Mark, MarkInfo>();
            CreateMap<MarkInfo, Mark>();
            CreateMap<DtoMark, Mark>();

            CreateMap<Category, CategoryInfo>();
            CreateMap<CategoryInfo, Category>();
            CreateMap<DtoCategory, Category>();

            CreateMap<Family, FamilyInfo>();
            CreateMap<FamilyInfo, Family>();
            CreateMap<DtoFamily, Family>();
        }
    }
}
