namespace Blogi.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<BaseCommandResponse<bool>>
    {
        public int Id { get; set; }
    }
}