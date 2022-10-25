using Blogi.Application.Features.Languages.Dtos.Create;

namespace Blogi.Application.Features.Languages.Commands.Create
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, BaseCommandResponse<CreateLanguageOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ILanguageReadRepository _languageReadRepository;

        public CreateLanguageCommandHandler(
            IMapper mapper, 
            ILanguageWriteRepository languageWriteRepository,
            ILanguageReadRepository languageReadRepository
            )
        {
            _mapper = mapper;
            _languageWriteRepository = languageWriteRepository;
            _languageReadRepository = languageReadRepository;
        }

        public async Task<BaseCommandResponse<CreateLanguageOutput>> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateLanguageOutput>();
            var validator = new CreateLanguageCommandHandlerValidatior(_languageReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x=>x.ErrorMessage).ToList();

            }
            else
            {
                var mapperLanguage = _mapper.Map<Language>(request);
                var result = await _languageWriteRepository.AddAsync(mapperLanguage);
                var resultMapp = _mapper.Map<CreateLanguageOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;               
                response.Success = true;
                response.Message = LanguageMessages.CreatedSuccess;
                response.Errors = null;
            }

            return response;
            
        }
    }
}
