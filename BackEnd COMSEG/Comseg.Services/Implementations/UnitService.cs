using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;
        private readonly IMapper _mapper;

        public UnitService(IUnitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }
        public async Task<BaseResponseEntity<ICollection<UnitInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<UnitInfo?>>();
            try
            {
                var unit = await _repository.GetUnitInfoCollectionAsync();
                response.ResponseResult = unit;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponseEntity<UnitInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<UnitInfo?>();
            try
            {
                var unit = await _repository.GetUnitInfoByIdAsync(id);
                response.ResponseResult = unit;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponseEntity<int>> CreateAsync(DtoUnit request,string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Unit entity = _mapper.Map<Unit>(request);
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
        public async Task<BaseResponse> UpdateAsync(int id, DtoUnit request,string user)
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
