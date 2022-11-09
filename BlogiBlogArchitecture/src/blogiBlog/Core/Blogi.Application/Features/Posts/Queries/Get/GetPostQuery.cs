using Blogi.Application.Features.Posts.Dtos.Get;

namespace Blogi.Application.Features.Posts.Queries.Get
{
    public class GetPostQuery : IRequest<BaseCommandResponse<GetPostOutput>>
    {
        public int Id { get; set; }
    }
}