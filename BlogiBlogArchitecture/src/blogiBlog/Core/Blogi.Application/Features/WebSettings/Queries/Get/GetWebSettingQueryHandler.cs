using Blogi.Application.Features.WebSettings.Dtos.Get;

namespace Blogi.Application.Features.WebSettings.Queries.Get
{
    public class GetWebSettingQueryHandler : IRequestHandler<GetWebSettingQuery, BaseCommandResponse<GetWebSettingOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IWebSettingReadRepository _webSettingReadRepository;

        public GetWebSettingQueryHandler(IMapper mapper, IWebSettingReadRepository webSettingReadRepository)
        {
            _mapper = mapper;
            _webSettingReadRepository = webSettingReadRepository;
        }

        public async Task<BaseCommandResponse<GetWebSettingOutput>> Handle(GetWebSettingQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetWebSettingOutput>();
            var result = await _webSettingReadRepository.GetAll().FirstOrDefaultAsync();

            var resultMapp = _mapper.Map<GetWebSettingOutput>(result);
            response.Id = resultMapp.Id;
            response.Data = resultMapp;
            response.Success = true;
            response.Message = WebSettingMessages.GetByIdExists;
            response.Errors = null;

            return response;
        }
    }
}