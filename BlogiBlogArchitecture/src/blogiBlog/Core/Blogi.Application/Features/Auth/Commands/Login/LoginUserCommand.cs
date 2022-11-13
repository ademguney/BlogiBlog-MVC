namespace Blogi.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommand : IRequest<BaseCommandResponse<bool>>
    {
        public bool RememberMe { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}