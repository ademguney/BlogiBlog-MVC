namespace Blogi.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommandHandlerValidatior : AbstractValidator<CreateTagCommand>
    {
        private readonly ITagReadRepository _tagReadRepository;

        public CreateTagCommandHandlerValidatior(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;

            RuleFor(x => x.LanguageId)                
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
                .MaximumLength(255)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                 .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                 .WithMessage(TagMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateTagCommand e, CancellationToken token)
        {
            var result = await _tagReadRepository.GetAsync(x => x.Name == e.Name);
            return result == null;
        }
    }
}
