namespace Blogi.Application.Features.Languages.Commands.Create
{
    public class CreateLanguageCommandHandlerValidatior : AbstractValidator<CreateLanguageCommand>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        public CreateLanguageCommandHandlerValidatior(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;

            RuleFor(x => x.Name)
                .MaximumLength(255)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Culture)
                 .MaximumLength(10)
                 .NotEmpty()
                 .NotNull();

            RuleFor(x => x)
                .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                .WithMessage(LanguageMessages.NameExists);
        }

        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(CreateLanguageCommand e,
        CancellationToken token)
        {
            return !await _languageReadRepository.AnyAsync(x => x.Name == e.Name);
        }
    }
}
