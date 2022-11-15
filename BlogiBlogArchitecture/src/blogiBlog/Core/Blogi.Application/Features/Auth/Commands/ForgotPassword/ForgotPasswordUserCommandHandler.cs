using Core.Application.Helpers;
using Core.Application.Security.Hashing;

namespace Blogi.Application.Features.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordUserCommandHandler : IRequestHandler<ForgotPasswordUserCommand, BaseCommandResponse<bool>>
    {
        private readonly IMailFactoryService _mailFactoryService;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public ForgotPasswordUserCommandHandler(
            IMailFactoryService mailFactoryService,
            IUserReadRepository userReadRepository,
            IUserWriteRepository userWriteRepository
            )
        {
            _mailFactoryService = mailFactoryService;
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<BaseCommandResponse<bool>> Handle(ForgotPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<bool>();
            var validator = new ForgotPasswordUserCommandHandlerValidatior(_userReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = false;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                // TODO: Send new password or forgot password link?
                var result = await _userReadRepository.GetAsync(x => x.Email == request.Email);
                var newPassword = "BLOGI_" + GeneratePassword.GenerateRandomPassword();

                // Send mail
                await _mailFactoryService.SendForgotPasswordMail(request.Email, newPassword);

                var passEncrypt = EnDecode.Encrypt(newPassword, StaticParams.PasswordParams);
                result.Password = passEncrypt;
                await _userWriteRepository.UpdateAsync(result);

                response.Data = true;
                response.Success = true;
                response.Message = AuthMessages.SendNewPassword;
                response.Errors = null;
            }

            return response;
        }
    }
}