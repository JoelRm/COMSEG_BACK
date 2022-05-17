using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _repository;
        private readonly IMapper _mapper;

        public MarkService(IMarkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<MarkInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<MarkInfo?>>();
            try
            {
                var mark = await _repository.GetMarkInfoCollectionAsync();
                response.ResponseResult = mark;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseEntity<MarkInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<MarkInfo?>();
            try
            {
                var mark = await _repository.GetMarkInfoByIdAsync(id);
                response.ResponseResult = mark;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message); 
            }

            return response;
        }

        public async Task<BaseResponseEntity<int>> CreateAsync(DtoMark request, string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Mark entity = _mapper.Map<Mark>(request);
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

        public async Task<BaseResponse> UpdateAsync(int id, DtoMark request, string user)
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
