namespace Blogi.Application.Features.Posts.Commands.Delete
{
    public class DeletePostCommandHandlerValidatior : AbstractValidator<DeletePostCommand>
    {
        private readonly IPostReadRepository _postReadRepository;

        public DeletePostCommandHandlerValidatior(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
               .MustAsync(IdIsNotExists)
               .WithMessage(PostMessages.GetByIdNotExists);

        }

        private async Task<bool> IdIsNotExists(DeletePostCommand e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}