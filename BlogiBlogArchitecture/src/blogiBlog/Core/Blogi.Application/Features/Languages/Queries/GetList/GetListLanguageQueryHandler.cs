using Blogi.Application.Features.Languages.Dtos.GetList;

namespace Blogi.Application.Features.Languages.Queries.GetList
{
    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, BaseCommandResponse<List<GetListLanguageOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageReadRepository _languageReadRepository;

        public GetListLanguageQueryHandler(IMapper mapper, ILanguageReadRepository languageReadRepository)
        {
            _mapper = mapper;
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseCommandResponse<List<GetListLanguageOutput>>> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListLanguageOutput>>();
            var result = await _languageReadRepository.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = LanguageMessages.GetListNotExists;
                response.Errors = null;
                response.Data = null;
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetListLanguageOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = LanguageMessages.GetListExists;
                response.Errors = null;
            }

            return response;

        }
    }
}
