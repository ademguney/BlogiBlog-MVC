using Blogi.Application.Features.StringResources.Dtos.GetList;

namespace Blogi.Application.Features.StringResources.Queries.GetList
{
    public class GetListStringResourceQuery : IRequest<BaseCommandResponse<List<GetListStringResourceOutput>>>
    {
    }
}
