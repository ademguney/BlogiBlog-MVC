namespace Blogi.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommandHandlerValidator : AbstractValidator<DeleteLanguageCommand>
    {
        private readonly ILanguageReadRepository _languageReadRepository;

        public DeleteLanguageCommandHandlerValidator(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(LanguageMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(DeleteLanguageCommand e, CancellationToken token)
        {
            var result = await _languageReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}
