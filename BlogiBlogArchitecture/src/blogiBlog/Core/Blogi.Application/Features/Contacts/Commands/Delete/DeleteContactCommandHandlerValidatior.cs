using Blogi.Application.Features.Contacts.Constants;

namespace Blogi.Application.Features.Contacts.Commands.Delete
{
    public class DeleteContactCommandHandlerValidatior : AbstractValidator<DeleteContactCommand>
    {
        private readonly IContactReadRepository _contactReadRepository;

        public DeleteContactCommandHandlerValidatior(IContactReadRepository contactReadRepository)
        {
            _contactReadRepository = contactReadRepository;

            RuleFor(x => x.Id)
                          .NotEmpty()
                          .NotNull();

            RuleFor(x => x)
                .MustAsync(IdIsNotExists)
                .WithMessage(ContactMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(DeleteContactCommand e, CancellationToken token)
        {
            var result = await _contactReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}