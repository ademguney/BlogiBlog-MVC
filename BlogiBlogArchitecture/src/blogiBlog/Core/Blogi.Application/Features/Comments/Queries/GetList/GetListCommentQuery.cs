using Blogi.Application.Features.Comments.Dtos.GetList;

namespace Blogi.Application.Features.Comments.Queries.GetList
{
    public class GetListCommentQuery : IRequest<BaseCommandResponse<List<GetListCommentOutput>>>
    {
    }
}