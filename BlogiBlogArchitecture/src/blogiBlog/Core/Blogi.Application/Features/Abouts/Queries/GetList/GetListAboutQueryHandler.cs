using Blogi.Application.Features.Abouts.Dtos.GetList;

namespace Blogi.Application.Features.Abouts.Queries.GetList
{
    public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, BaseCommandResponse<List<GetListAboutOutput>>>
    {
        private readonly IAboutService _aboutService;

        public GetListAboutQueryHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<BaseCommandResponse<List<GetListAboutOutput>>> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListAboutOutput>>();
            var result = await _aboutService.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = AboutMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetListAboutOutput>();
            }
            else
            {
                response.Data = result;
                response.Success = true;
                response.Message = AboutMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}