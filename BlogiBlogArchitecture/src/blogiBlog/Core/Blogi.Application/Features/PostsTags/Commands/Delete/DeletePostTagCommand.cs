namespace Blogi.Application.Features.PostsTags.Commands.Delete
{
    public class DeletePostTagCommand: IRequest<BaseCommandResponse<int>>
    {
        public int PostId { get; set; }
    }
}
