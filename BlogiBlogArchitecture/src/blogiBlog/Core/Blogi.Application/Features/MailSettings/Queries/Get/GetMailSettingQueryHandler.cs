using Blogi.Application.Features.MailSettings.Dtos.Get;
using Core.Application.Security.Hashing;

namespace Blogi.Application.Features.MailSettings.Queries.Get
{
    public class GetMailSettingQueryHandler : IRequestHandler<GetMailSettingQuery, BaseCommandResponse<GetMailSettingOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IMailSettingReadRepository _mailSettingReadRepository;

        public GetMailSettingQueryHandler(IMapper mapper, IMailSettingReadRepository mailSettingReadRepository)
        {
            _mapper = mapper;
            _mailSettingReadRepository = mailSettingReadRepository;
        }

        public Task<BaseCommandResponse<GetMailSettingOutput>> Handle(GetMailSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetMailSettingOutput>();

            var result = _mailSettingReadRepository.GetAll().FirstOrDefault();
            result.Password = EnDecode.Decrypt(result.Password, StaticParams.PasswordParams);

            var resultMapp = _mapper.Map<GetMailSettingOutput>(result);
            response.Id = resultMapp.Id;
            response.Data = resultMapp;
            response.Success = true;
            response.Message = MailSettingMessages.GetByIdExists;
            response.Errors = null;

            return Task.FromResult(response);
        }
    }
}