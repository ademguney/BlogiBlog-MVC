using Blogi.Application.Features.Users.Dtos.Get;
using Core.Application.Security.Hashing;

namespace Blogi.Application.Features.Users.Queries.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, BaseCommandResponse<GetUserOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;

        public GetUserQueryHandler(IMapper mapper, IUserReadRepository userReadRepository)
        {
            _mapper = mapper;
            _userReadRepository = userReadRepository;
        }

        public async Task<BaseCommandResponse<GetUserOutput>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetUserOutput>();
            var validator = new GetUserQueryHandlerValidatior(_userReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var result = await _userReadRepository.GetAsync(x => x.Id == request.Id);
                result.Password = EnDecode.Decrypt(result.Password, StaticParams.PasswordParams);
                var resultMapp = _mapper.Map<GetUserOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = UserMessages.GetByIdExists;
                response.Errors = null;
            }

            return response;
        }
    }
}