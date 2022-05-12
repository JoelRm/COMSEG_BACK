using AutoMapper;
using Comseg.DataAccess.Interfaces;
using Comseg.DTO.Request;
using Comseg.DTO.Response;
using Comseg.Entities;
using Comseg.Entities.Complex;
using Comseg.Services.Interfaces;

namespace Comseg.Services.Implementations
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public BranchService(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponseEntity<ICollection<BranchInfo?>>> GetCollectionAsync()
        {
            var response = new BaseResponseEntity<ICollection<BranchInfo?>>();
            try
            {
                var branch = await _repository.GetBranchInfoCollectionAsync();
                response.ResponseResult = branch;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponseEntity<BranchInfo?>> GetByIdAsync(int id)
        {
            var response = new BaseResponseEntity<BranchInfo?>();
            try
            {
                var branch = await _repository.GetBranchInfoByIdAsync(id);
                response.ResponseResult = branch;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ListErrors.Add(ex.Message);
            }

            return response;
        }
        public async Task<BaseResponseEntity<int>> CreateAsync(DtoBranch request, string user)
        {
            var response = new BaseResponseEntity<int>();
            try
            {
                Branch entity = _mapper.Map<Branch>(request);
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
        public async Task<BaseResponse> UpdateAsync(int id, DtoBranch request, string user)
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
