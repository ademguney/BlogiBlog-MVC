namespace Blogi.Application.Features.Abouts.Commands.Delete
{
    public class DeleteAboutCommandHandlerValidatior : AbstractValidator<DeleteAboutCommand>
    {
        private readonly IAboutReadRepository _aboutReadRepository;

        public DeleteAboutCommandHandlerValidatior(IAboutReadRepository aboutReadRepository)
        {
            _aboutReadRepository = aboutReadRepository;

            RuleFor(x => x.Id)
                           .NotEmpty()
                           .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(AboutMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(DeleteAboutCommand e, CancellationToken token)
        {
            var result = await _aboutReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}