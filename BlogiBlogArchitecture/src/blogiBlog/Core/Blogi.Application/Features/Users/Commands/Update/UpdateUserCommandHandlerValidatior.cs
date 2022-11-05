namespace Blogi.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandlerValidatior : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserReadRepository _userReadRepository;

        public UpdateUserCommandHandlerValidatior(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;

            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.Name)
              .MaximumLength(255)
              .NotEmpty()
              .NotNull();

            RuleFor(x => x.Surname)
            .MaximumLength(255)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.Email)
            .MaximumLength(255)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x)
                  .MustAsync(IdIsNotExists)
                  .WithMessage(TagMessages.GetByIdNotExists);
        }
        private async Task<bool> IdIsNotExists(UpdateUserCommand e, CancellationToken token)
        {
            var result = await _userReadRepository.GetAsync(x => x.Id == e.Id);
            return result != null;
        }
    }
}