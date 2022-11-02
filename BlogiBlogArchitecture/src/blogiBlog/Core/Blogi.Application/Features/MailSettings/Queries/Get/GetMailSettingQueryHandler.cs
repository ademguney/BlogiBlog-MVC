using Blogi.Application.Features.MailSettings.Dtos.Get;
using Core.Application.Security.Hashing;
using Microsoft.EntityFrameworkCore;

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

        public async Task<BaseCommandResponse<GetMailSettingOutput>> Handle(GetMailSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetMailSettingOutput>();

            var result =await _mailSettingReadRepository.GetAll().FirstOrDefaultAsync();
            result.Password = EnDecode.Decrypt(result.Password, StaticParams.PasswordParams);

            var resultMapp = _mapper.Map<GetMailSettingOutput>(result);
            response.Id = resultMapp.Id;
            response.Data = resultMapp;
            response.Success = true;
            response.Message = MailSettingMessages.GetByIdExists;
            response.Errors = null;

            return response;
        }
    }
}