using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class LineService : ILineService 
    {
        private readonly ILineRepository _repository;
        private readonly IMapper _mapper;

        public LineService(ILineRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<LineInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<LineInfo?>>();
            try
            {
                var line = await _repository.GetLineInfoCollectionAsync();
                response.ResponseResult = line;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<LineInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<LineInfo?>();
            try
            {
                var line = await _repository.GetLineInfoByIdAsync(id);
                response.ResponseResult = line;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success= false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponseEntity<int>> CreateAsync(DtoLine request, string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Line entity = _mapper.Map<Line>(request);
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
        public async Task<BaseResponse> UpdateAsync(int id, DtoLine request, string user)
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
