namespace Blogi.Application.Features.PostsTags.Commands.Create
{
    public class CreatePostTagCommand : IRequest<BaseCommandResponse<int>>
    {
        public int PostId { get; set; }
        public int[] TagIds { get; set; }
    }
}