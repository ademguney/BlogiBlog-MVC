using Blogi.Application.Features.StringResources.Dtos.Get;
using Blogi.Application.Features.StringResources.Dtos.GitList;

namespace Blogi.Application.Services.StringResourceService
{
    public interface IStringResourceService
    {
        Task<GetStringResourceOutput> GetAsync(int id);
        List<GetListStringResourceOutput> GetList();
    }
}
