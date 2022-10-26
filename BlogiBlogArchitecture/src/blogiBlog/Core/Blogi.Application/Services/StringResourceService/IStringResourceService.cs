using Blogi.Application.Features.StringResources.Dtos.GitList;

namespace Blogi.Application.Services.StringResourceService
{
    public interface IStringResourceService
    {
        List<GetListStringResourceOutput> GetList();
    }
}
