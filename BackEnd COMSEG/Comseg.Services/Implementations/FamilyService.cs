using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _repository;
        private readonly IMapper _mapper;

        public FamilyService(IFamilyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<FamilyInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<FamilyInfo?>>();
            try
            {
                var family = await _repository.GetFamilyInfoCollectionAsync();
                response.ResponseResult = family;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<FamilyInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<FamilyInfo?>();
            try
            {
                var family = await _repository.GetFamilyInfoByIdAsync(id);
                response.ResponseResult = family;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<int>> CreateAsync(DtoFamily request, string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Family entity = _mapper.Map<Family>(request);
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
        public async Task<BaseResponse> UpdateAsync(int id, DtoFamily request, string user)
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
