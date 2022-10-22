namespace Blogi.Application.Features.Languages.Queries.Get
{
    public class GetLanguageQueryHandlerValidator : AbstractValidator<GetLanguageQuery>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        public GetLanguageQueryHandlerValidator(ILanguageReadRepository languageReadRepository)
        {
            _languageReadRepository = languageReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(LanguageMessages.GetByIdNotExists);
        }

        private async Task<bool> IdIsNotExists(GetLanguageQuery e, CancellationToken token)
        {
            return !await _languageReadRepository.AnyAsync(x => x.Id == e.Id);
        }
    }
}
