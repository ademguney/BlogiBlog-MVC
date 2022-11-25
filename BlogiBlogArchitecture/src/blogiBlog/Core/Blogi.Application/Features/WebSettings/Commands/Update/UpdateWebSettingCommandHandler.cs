using Blogi.Application.Features.WebSettings.Dtos.Get;

namespace Blogi.Application.Features.WebSettings.Commands.Update
{
    public class UpdateWebSettingCommandHandler : IRequestHandler<UpdateWebSettingCommand, BaseCommandResponse<GetWebSettingOutput>>
    {
        private readonly IMapper _mapper;       
        private readonly IWebSettingWriteRepository _webSettingWriteRepository;

        public UpdateWebSettingCommandHandler(IMapper mapper, IWebSettingWriteRepository webSettingWriteRepository)
        {
            _mapper = mapper;         
            _webSettingWriteRepository = webSettingWriteRepository;
        }

        public async Task<BaseCommandResponse<GetWebSettingOutput>> Handle(UpdateWebSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetWebSettingOutput>();
            var validator = new UpdateWebSettingCommandHandlerValidatior();
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
                var webSettingMapp = _mapper.Map<WebSetting>(request);
                var result = await _webSettingWriteRepository.UpdateAsync(webSettingMapp);
                var resultMapp = _mapper.Map<GetWebSettingOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = WebSettingMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}