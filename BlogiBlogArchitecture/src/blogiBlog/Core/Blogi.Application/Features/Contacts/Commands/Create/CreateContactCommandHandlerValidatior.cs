namespace Blogi.Application.Features.Contacts.Commands.Create
{
    public class CreateContactCommandHandlerValidatior : AbstractValidator<CreateContactCommand>
    {
        private readonly IContactReadRepository _contactReadRepository;
        public CreateContactCommandHandlerValidatior(IContactReadRepository contactReadRepository)
        {
            _contactReadRepository = contactReadRepository;

            RuleFor(x => x.LanguageId)
              .NotEmpty()
              .NotNull();

            RuleFor(x => x.Phone)
                .MaximumLength(30);

            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(255);

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
        private async Task<bool> LanguageIdIsExists(CreateContactCommand e, CancellationToken token)
        {
            var result = await _contactReadRepository.GetAsync(x => x.LanguageId == e.LanguageId);
            return result == null;
        }
    }
}