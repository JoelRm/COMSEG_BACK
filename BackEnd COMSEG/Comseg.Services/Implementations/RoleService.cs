using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request.Role;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper; 

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task<BaseResponseEntity<ICollection<RoleInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<RoleInfo?>>();
            try
            {
                var role = await _repository.GetRoleInfoCollectionAsync();
                response.ResponseResult = role;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<RoleInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<RoleInfo?>();
            try
            {
                var role = await _repository.GetRoleInfoByIdAsync(id);
                response.ResponseResult = role;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<int>> CreateAsync(DtoRole request, string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Role entity = _mapper.Map<Role>(request);
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

        public async Task<BaseResponse> UpdateAsync(int id, DtoRole request,string user)
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
