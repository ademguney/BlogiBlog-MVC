namespace Blogi.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandlerValidatior : AbstractValidator<LoginUserCommand>
    {
        private readonly IUserReadRepository _userReadRepository;

        public LoginUserCommandHandlerValidatior(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x)
              .MustAsync(EmailIsNotExists)
              .WithMessage(AuthMessages.EmailNotExists);
        }
        private async Task<bool> EmailIsNotExists(LoginUserCommand e, CancellationToken token)
        {
            var result = await _userReadRepository.GetAsync(x => x.Email == e.Email);
            if (result is not null)
            {
                var passDecrypt = EnDecode.Decrypt(result.Password, StaticParams.PasswordParams);
                if (passDecrypt != e.Password)
                    return result != null;
            }
            return result != null;
        }

    }
}