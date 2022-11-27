namespace Blogi.Application.Features.Tags.Commands.Delete
{
    public class DeleteTagCommandHandlerValidatior : AbstractValidator<DeleteTagCommand>
    {
        private readonly ITagReadRepository _tagReadRepository;

        public DeleteTagCommandHandlerValidatior(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;

            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(TagMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(DeleteTagCommand e, CancellationToken token)
        {
            var result = await _tagReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}