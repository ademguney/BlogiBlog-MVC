namespace Blogi.Application.Features.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordUserCommandHandlerValidatior : AbstractValidator<ForgotPasswordUserCommand>
    {
        private readonly IUserReadRepository _userReadRepository;

        public ForgotPasswordUserCommandHandlerValidatior(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;

            RuleFor(x => x.Email)
               .EmailAddress()
               .NotEmpty()
               .NotNull();

            RuleFor(x => x)
              .MustAsync(EmailIsNotExists)
              .WithMessage(AuthMessages.EmailNotFound);

        }

        private async Task<bool> EmailIsNotExists(ForgotPasswordUserCommand e, CancellationToken token)
        {
            var result = await _userReadRepository.GetAsync(x => x.Email == e.Email);
            return result != null;
        }
    }
}