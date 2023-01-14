namespace Blogi.Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<BaseCommandResponse<bool>>
    {
        public int ParentId { get; set; }
        public int PostId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsPublish { get; set; } = false;
    }
}