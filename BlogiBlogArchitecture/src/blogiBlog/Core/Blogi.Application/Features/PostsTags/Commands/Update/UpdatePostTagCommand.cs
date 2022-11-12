namespace Blogi.Application.Features.PostsTags.Commands.Update
{
    public class UpdatePostTagCommand : IRequest<BaseCommandResponse<List<int>>>
    {
        public int PostId { get; set; }
        public List<int> TagIds { get; set; }
    }
}