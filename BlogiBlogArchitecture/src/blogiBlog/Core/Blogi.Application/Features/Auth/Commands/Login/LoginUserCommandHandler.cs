using Blogi.Application.Features.Auth.Dto.GetLogin;
using Core.Application.FormAuth.ClaimServices;
using Core.Application.FormAuth.CookieScheme;

namespace Blogi.Application.Features.Auth.Commands.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseCommandResponse<GetLoginOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IClaimCoreService _claimService;
        private readonly IUserReadRepository _userReadRepository;

        public LoginUserCommandHandler(
            IMapper mapper,
            IClaimCoreService claimService,
            IUserReadRepository userReadRepository
            )
        {
            _mapper = mapper;
            _claimService = claimService;
            _userReadRepository = userReadRepository;
        }

        public async Task<BaseCommandResponse<GetLoginOutput>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetLoginOutput>();
            var validator = new LoginUserCommandHandlerValidatior(_userReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
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
                }, AuthDefaults.Scheme);

                var resultMapp = _mapper.Map<GetLoginOutput>(result);

                response.Id = result.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = AuthMessages.EmailOrPassCorrect;
                response.Errors = null;
            }

            return response;
        }
    }
}
