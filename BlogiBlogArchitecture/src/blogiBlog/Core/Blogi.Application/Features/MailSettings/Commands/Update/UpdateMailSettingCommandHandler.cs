using Blogi.Application.Features.MailSettings.Dtos.Get;
using Core.Application.Security.Hashing;

namespace Blogi.Application.Features.MailSettings.Commands.Update
{
    public class UpdateMailSettingCommandHandler : IRequestHandler<UpdateMailSettingCommand, BaseCommandResponse<GetMailSettingOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IMailSettingWriteRepository _mailSettingWriteRepository;


        public UpdateMailSettingCommandHandler(IMapper mapper, IMailSettingWriteRepository mailSettingWriteRepository)
        {
            _mapper = mapper;
            _mailSettingWriteRepository = mailSettingWriteRepository;
        }

        public async Task<BaseCommandResponse<GetMailSettingOutput>> Handle(UpdateMailSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetMailSettingOutput>();
            var validator = new UpdateMailSettingCommandHandlerValidator();
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

                var mailSettingMapp = _mapper.Map<MailSetting>(request);
                var result = await _mailSettingWriteRepository.UpdateAsync(mailSettingMapp);

                var resultMapp = _mapper.Map<GetMailSettingOutput>(result);
                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = MailSettingMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}