using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request.Menu;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _repository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<MenuInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<MenuInfo?>>();
            try
            {
                var menu = await _repository.GetMenuInfoCollectionAsync();
                response.ResponseResult = menu;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponseEntity<MenuInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<MenuInfo?>();
            try
            {
                var menu = await _repository.GetMenuInfoByIdAsync(id);
                response.ResponseResult = menu;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponseEntity<int>> CreateAsync(DtoMenu request,string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Menu entity = _mapper.Map<Menu>(request);
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
        public async Task<BaseResponse> UpdateAsync(int id, DtoMenu request, string user)
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
