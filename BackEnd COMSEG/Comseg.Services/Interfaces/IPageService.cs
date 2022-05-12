using Comseg.DTO.Response;

namespace Comseg.Services.Interfaces
{
    public interface IPageService
    {
        Task<BaseResponsePages<PagesResponse>> GetCollectionAsync(int id);
    }
}
