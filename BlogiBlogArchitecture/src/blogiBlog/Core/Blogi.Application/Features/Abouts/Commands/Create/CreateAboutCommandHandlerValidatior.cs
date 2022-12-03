namespace Blogi.Application.Features.Abouts.Commands.Create
{
    public class CreateAboutCommandHandlerValidatior : AbstractValidator<CreateAboutCommand>
    {
        private readonly IAboutReadRepository _aboutReadRepository;
        public CreateAboutCommandHandlerValidatior(IAboutReadRepository aboutReadRepository)
        {
            _aboutReadRepository = aboutReadRepository;

            RuleFor(x => x.LanguageId)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.Content)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.Title)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.Slug)
           .MaximumLength(500)
           .NotEmpty()
           .NotNull();

            RuleFor(x => x.MetaKeywords)
             .MaximumLength(500)
             .NotEmpty()
             .NotNull();

            RuleFor(x => x.MetaDescription)
            .MaximumLength(500)
            .NotEmpty()
            .NotNull();
            
            RuleFor(x => x)
                  .MustAsync(LanguageIdIsExists)
                  .WithMessage(ContactMessages.LanguageIdExists);
        }
        private async Task<bool> LanguageIdIsExists(CreateAboutCommand e, CancellationToken token)
        {
            var result = await _aboutReadRepository.GetAsync(x => x.LanguageId == e.LanguageId);
            return result == null;
        }
    }
}