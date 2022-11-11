namespace Blogi.Application.Features.Posts.Commands.Delete
{
    public class DeletePostCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
}