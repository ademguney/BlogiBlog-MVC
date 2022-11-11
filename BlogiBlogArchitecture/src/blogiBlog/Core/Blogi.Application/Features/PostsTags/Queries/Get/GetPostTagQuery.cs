namespace Blogi.Application.Features.PostsTags.Queries.Get
{
    public class GetPostTagQuery : IRequest<BaseCommandResponse<List<int>>>
    {
        public int PostId { get; set; }
    }
}