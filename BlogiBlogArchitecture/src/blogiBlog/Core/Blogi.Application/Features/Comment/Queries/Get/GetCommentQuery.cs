using Blogi.Application.Features.Comment.Dtos.Get;

namespace Blogi.Application.Features.Comment.Queries.Get
{
    public class GetCommentQuery : IRequest<BaseCommandResponse<GetCommentOutput>>
    {
        public int Id { get; set; }
    }
}