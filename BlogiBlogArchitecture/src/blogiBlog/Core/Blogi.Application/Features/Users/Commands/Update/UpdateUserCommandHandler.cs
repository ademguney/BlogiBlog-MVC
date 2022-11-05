using Blogi.Application.Features.Users.Dtos.Get;
using Core.Application.Security.Hashing;

namespace Blogi.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse<GetUserOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _mapper = mapper;
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<BaseCommandResponse<GetUserOutput>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetUserOutput>();
            var validator = new UpdateUserCommandHandlerValidatior(_userReadRepository);
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
                request.Password = EnDecode.Encrypt(request.Password, StaticParams.PasswordParams);
                var user=await _userReadRepository.GetAsync(x=>x.Id== request.Id);

                user.Photo= request.Photo ?? user.Photo;
                user.Name = request.Name;
                user.Surname = request.Surname;
                user.Email = request.Email;
                user.Password=request.Password;
                var result = await _userWriteRepository.UpdateAsync(user);

                user.Password = EnDecode.Decrypt(user.Password, StaticParams.PasswordParams);
                var resultMapp = _mapper.Map<GetUserOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = UserMessages.UpdatedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}