namespace Blogi.Application.Features.Comments.Commands.IsPublish
{
    public class IsPublishCommentCommand : IRequest<BaseCommandResponse<bool>>
    {
        public int Id { get; set; }
        public bool IsPublish { get; set; }
    }
}