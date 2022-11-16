namespace Blogi.Application.Features.Comment.Commands.CommentCreate
{
    public class CreateCommentCommandHandlerValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandHandlerValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull();
        }
    }
}