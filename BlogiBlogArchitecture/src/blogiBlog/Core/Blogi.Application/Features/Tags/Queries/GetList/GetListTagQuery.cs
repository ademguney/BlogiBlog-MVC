using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Queries.GetList
{
    public class GetListTagQuery : IRequest<BaseCommandResponse<List<GetTagOutput>>>
    {
    }
}