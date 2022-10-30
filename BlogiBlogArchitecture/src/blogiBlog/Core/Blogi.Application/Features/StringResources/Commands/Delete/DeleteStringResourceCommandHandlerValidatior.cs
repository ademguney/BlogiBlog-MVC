namespace Blogi.Application.Features.StringResources.Commands.Delete
{
    public class DeleteStringResourceCommandHandlerValidatior : AbstractValidator<DeleteStringResourceCommand>
    {
        private readonly IStringResourceReadRepository _stringResourceReadRepository;

        public DeleteStringResourceCommandHandlerValidatior(IStringResourceReadRepository stringResourceReadRepository)
        {
            _stringResourceReadRepository = stringResourceReadRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(StringResourceMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(DeleteStringResourceCommand e, CancellationToken token)
        {
            var result = await _stringResourceReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}
