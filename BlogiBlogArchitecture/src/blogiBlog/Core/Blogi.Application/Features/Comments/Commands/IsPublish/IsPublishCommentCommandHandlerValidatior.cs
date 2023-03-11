using Blogi.Application.Features.Comments.Commands.Delete;

namespace Blogi.Application.Features.Comments.Commands.IsPublish
{
    public class IsPublishCommentCommandHandlerValidatior : AbstractValidator<IsPublishCommentCommand>
    {
        private readonly ICommentReadRepository _commentReadRepository;

        public IsPublishCommentCommandHandlerValidatior(ICommentReadRepository commentReadRepository)
        {
            _commentReadRepository = commentReadRepository;

            RuleFor(x => x.Id)
                          .NotEmpty()
                          .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(CommentMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(IsPublishCommentCommand e, CancellationToken token)
        {
            var result = await _commentReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}