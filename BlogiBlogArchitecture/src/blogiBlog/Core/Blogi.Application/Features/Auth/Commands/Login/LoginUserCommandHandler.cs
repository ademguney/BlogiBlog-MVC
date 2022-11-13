using Core.Application.FormAuth.CookieScheme;

namespace Blogi.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseCommandResponse<bool>>
    {

        private readonly IClaimService _claimService;
        private readonly IUserReadRepository _userReadRepository;

        public LoginUserCommandHandler(
            IClaimService claimService,
            IUserReadRepository userReadRepository
            )
        {
            _claimService = claimService;
            _userReadRepository = userReadRepository;
        }

        public async Task<BaseCommandResponse<bool>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<bool>();
            var validator = new LoginUserCommandHandlerValidatior(_userReadRepository);
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
                var result = await _userReadRepository.GetAsync(x => x.Email == request.Email);
                await _claimService.CreateAsync(new Core.Application.FormAuth.ClaimInfo.ClaimCoreInfo
                {
                    UserId = result.Id,
                    RememberMe = request.RememberMe,
                    Email = result.Email,
                    FirstName = result.Name,
                    LastName = result.Surname
                }, AuthDefault.Scheme);

                response.Id = result.Id;
                response.Data = true;
                response.Success = true;
                response.Message = AuthMessages.EmailOrPassCorrect;
                response.Errors = null;
            }

            return response;
        }
    }
}
