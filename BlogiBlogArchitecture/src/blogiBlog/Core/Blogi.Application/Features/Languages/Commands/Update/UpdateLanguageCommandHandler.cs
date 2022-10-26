using Blogi.Application.Features.Languages.Dtos.Update;

namespace Blogi.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, BaseCommandResponse<UpdateLanguageOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ILanguageReadRepository _languageReadRepository;

        public UpdateLanguageCommandHandler(
            IMapper mapper,
            ILanguageWriteRepository languageWriteRepository,
            ILanguageReadRepository languageReadRepository
            )
        {
            _mapper = mapper;
            _languageWriteRepository = languageWriteRepository;
            _languageReadRepository = languageReadRepository;
        }
        public async Task<BaseCommandResponse<UpdateLanguageOutput>> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateLanguageOutput>();
            var validator = new UpdateLanguageCommandHandlerValidator(_languageReadRepository);
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

                var languageMapp = _mapper.Map<Language>(request);
                var result = await _languageWriteRepository.UpdateAsync(languageMapp);
                var resultMapp = _mapper.Map<UpdateLanguageOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = LanguageMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
