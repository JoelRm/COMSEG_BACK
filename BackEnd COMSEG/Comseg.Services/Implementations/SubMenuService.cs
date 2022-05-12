using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request.SubMenu;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class SubMenuService : ISubMenuService
    {
        private readonly ISubMenuRepository _repository;
        private readonly IMapper _mapper;

        public SubMenuService(ISubMenuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<SubMenuInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<SubMenuInfo?>>();
            try
            {
                var submenu = await _repository.GetSubMenuInfoCollectionAsync();
                response.ResponseResult = submenu;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<SubMenuInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<SubMenuInfo?>();
            try
            {
                var submenu = await _repository.GetSubMenuInfoByIdAsync(id);
                response.ResponseResult = submenu;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<int>> CreateAsync(DtoSubMenu request,string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                SubMenu entity = _mapper.Map<SubMenu>(request);
                entity.CreationUser = user; 
                entity.CreationDate = DateTime.Now;

                response.ResponseResult = await _repository.CreateAsync(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, DtoSubMenu request, string user)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _repository.GetByIdAsync(id);

                _mapper.Map(request, entity);
                if (entity != null)
                {
                    entity.ModificationUser = user;
                    entity.ModificationDate = DateTime.Now;
                }
                await _repository.UpdateAsync();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.DeleteAsync(id);
                response.Success = true;
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
