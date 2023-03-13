namespace Blogi.Application.Features.Tags.Commands.Update
{
    public class UpdateTagCommandHandlerValidatior : AbstractValidator<UpdateTagCommand>
    {
        private readonly ITagReadRepository _tagReadRepository;

        public UpdateTagCommandHandlerValidatior(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Name)
              .MaximumLength(255)
              .NotEmpty()
              .NotNull();

            RuleFor(x => x)
               .MustAsync(NameCanNotBeDuplicatedWhenUpdated)
               .WithMessage(TagMessages.NameExists);
        }
        private async Task<bool> NameCanNotBeDuplicatedWhenUpdated(UpdateTagCommand e, CancellationToken token)
        {
            var result = await _tagReadRepository.GetAsync(x => x.Name == e.Name && x.LanguageId==e.LanguageId);
            return result == null;
        }
    }
}