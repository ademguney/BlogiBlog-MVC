using Blogi.Application.Features.StringResources.Dtos.Get;
using Blogi.Application.Features.StringResources.Dtos.GetList;

namespace Blogi.Application.Services.StringResourceService
{
    public interface IStringResourceService
    {
        Task<GetStringResourceOutput> GetAsync(int id);
        Task<GetStringResourceOutput> GetAsync(string resourceKey, int languageId);
        Task<List<GetListStringResourceOutput>> GetListAsync();
    }
}