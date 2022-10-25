using Blogi.Application.Features.StringResources.Dtos.GitList;

namespace Blogi.Application.Features.StringResources.Queries.GitList
{
    public class GetListStringResourceQuery : IRequest<BaseCommandResponse<List<GetListStringResourceOutput>>>
    {
    }
}
