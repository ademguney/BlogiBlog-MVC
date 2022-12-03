using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Queries.Get
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, BaseCommandResponse<GetAboutOutput>>
    {
        private readonly IAboutService _aboutService;

        public GetAboutQueryHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<BaseCommandResponse<GetAboutOutput>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetAboutOutput>();
            var result = await _aboutService.GetAsync(request.Id, request.Culture);
            response.Id = result.Id;
            response.Data = result;
            response.Success = true;
            response.Message = AboutMessages.GetByIdExists;
            response.Errors = null;

            return response;
        }
    }
}