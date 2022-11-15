namespace Blogi.Application.Features.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordUserCommand : IRequest<BaseCommandResponse<bool>>
    {
        public string Email { get; set; }
    }
}