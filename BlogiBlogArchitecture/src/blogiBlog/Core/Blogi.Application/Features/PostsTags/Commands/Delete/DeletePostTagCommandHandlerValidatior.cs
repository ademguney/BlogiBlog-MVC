namespace Blogi.Application.Features.PostsTags.Commands.Delete
{
    public class DeletePostTagCommandHandlerValidatior : AbstractValidator<DeletePostTagCommand>
    {
        private readonly IPostReadRepository _postReadRepository;

        public DeletePostTagCommandHandlerValidatior(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;

            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(PostTagMessages.PostIdIsNotExists);
        }

        private async Task<bool> IdIsNotExists(DeletePostTagCommand e, CancellationToken token)
        {
            var result = await _postReadRepository.GetAsync(x => x.Id == e.PostId);
            return result != null;
        }
    }
}