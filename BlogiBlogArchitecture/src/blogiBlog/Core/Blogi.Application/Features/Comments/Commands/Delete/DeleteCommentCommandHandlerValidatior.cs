using Blogi.Application.Features.Comments.Constants;

namespace Blogi.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommandHandlerValidatior : AbstractValidator<DeleteCommentCommand>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public DeleteCommentCommandHandlerValidatior(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;

            RuleFor(x => x.Id)
                          .NotEmpty()
                          .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(CommentMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(DeleteCommentCommand e, CancellationToken token)
        {
            var result = await _commentReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}