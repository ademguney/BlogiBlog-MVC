using Blogi.Application.Features.Comments.Dtos.Get;

namespace Blogi.Application.Features.Comments.Queries.Get
{
    public class GetCommentQuery : IRequest<BaseCommandResponse<GetCommentOutput>>
    {
        public int Id { get; set; }
    }
}