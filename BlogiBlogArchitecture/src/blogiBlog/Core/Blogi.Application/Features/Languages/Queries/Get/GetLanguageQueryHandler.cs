using Blogi.Application.Features.Languages.Dtos.Get;

namespace Blogi.Application.Features.Languages.Queries.Get
{
    public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, BaseCommandResponse<GetLanguageOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageReadRepository _languageReadRepository;


        public GetLanguageQueryHandler(IMapper mapper, ILanguageReadRepository languageReadRepository)
        {
            _mapper = mapper;
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseCommandResponse<GetLanguageOutput>> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetLanguageOutput>();
            var validator = new GetLanguageQueryHandlerValidatior(_languageReadRepository);
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
                var result = await _languageReadRepository.GetAsync(x => x.Id == request.Id);
                var resultMapp = _mapper.Map<GetLanguageOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = LanguageMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
