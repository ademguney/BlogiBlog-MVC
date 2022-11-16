using Blogi.Application.Features.Comment.Dtos.GetList;

namespace Blogi.Application.Features.Comment.Queries.GetList
{
    public class GetListCommentQuery : IRequest<BaseCommandResponse<List<GetListCommentOutput>>>
    {
    }
}