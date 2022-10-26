namespace Blogi.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommandHandlerValidator : AbstractValidator<UpdateLanguageCommand>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        public UpdateLanguageCommandHandlerValidator(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
               .MaximumLength(255)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Culture)
                 .MaximumLength(10)
                 .NotEmpty()
                 .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(LanguageMessages.GetByIdNotExists);

            RuleFor(x => x)
                .MustAsync(NameCanNotBeDuplicatedWhenInserted)
                .WithMessage(LanguageMessages.NameExists);
        }

        private async Task<bool> IdIsNotExists(UpdateLanguageCommand e, CancellationToken token)
        {
            var result = await _languageReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }

        private async Task<bool> NameCanNotBeDuplicatedWhenInserted(UpdateLanguageCommand e,
        CancellationToken token)
        {
            var result = await _languageReadRepository.GetAsync(x => x.Name == e.Name);
            return result == null;
        }
    }
}