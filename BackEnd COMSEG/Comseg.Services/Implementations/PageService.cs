using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Response;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class PageService : IPageService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly ISubMenuRepository _subMenuRepository;
        private readonly IMapper _mapper;
        public PageService(IRoleRepository roleRepository, IMenuRepository menuRepository, ISubMenuRepository subMenuRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _menuRepository = menuRepository;
            _subMenuRepository = subMenuRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponsePages<PagesResponse>> GetCollectionAsync(int id)
        {
            var response = new BaseResponsePages<PagesResponse>();
            response.PageResponse = new PagesResponse();
            response.PageResponse.SubMenuResponse = new List<SubMenuResponse>();
            response.PageResponse.MenuResponse = new List<MenuResponse>();

            try
            {
                var role = await _roleRepository.GetByIdAsync(id);
                var menu = await _menuRepository.GetCollectionAsync();
                var submenu = await   _subMenuRepository.GetCollectionAsync();
                List<SubMenuResponse> SubmenuPages = new List<SubMenuResponse>();
                List<MenuResponse> MenuPages = new List<MenuResponse>();

                var listSubMenu = _mapper.Map< List<SubMenuResponse?>>(submenu);
                var listMenu = _mapper.Map<List<MenuResponse?>>(menu);

                if (role == null) return response;

                var permisos = role.RolePermissions.Split(",");

                for (int i = 0; i < permisos.Length; i++)
                {
                    if (permisos[i] == "1")
                    {
                        SubmenuPages.Add(listSubMenu[i]);
                    }
                }

                var distinct = (from M in listMenu
                                join S in SubmenuPages on M.MenuId equals S.MenuId
                                select M).ToList().Distinct();

                MenuPages = distinct.ToList();

                response.Success = true;
                response.PageResponse.SubMenuResponse = SubmenuPages;
                response.PageResponse.MenuResponse = MenuPages;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }


    }
}
