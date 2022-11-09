using Blogi.Application.Features.Posts.Dtos.GetList;

namespace Blogi.Application.Features.Posts.Queries.GetList
{
    public class GetListPostQuery : IRequest<BaseCommandResponse<List<GetListPostOutput>>>
    {

    }
}