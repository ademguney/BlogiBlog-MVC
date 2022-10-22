using Blogi.Application.Features.Languages.Dtos.Delete;

namespace Blogi.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, BaseCommandResponse<DeleteLanguageOutput>>
    {
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ILanguageWriteRepository _languageWriteRepository;

        public DeleteLanguageCommandHandler(
            ILanguageReadRepository languageReadRepository,
            ILanguageWriteRepository languageWriteRepository)
        {
            _languageReadRepository = languageReadRepository;
            _languageWriteRepository = languageWriteRepository;
        }

        public async Task<BaseCommandResponse<DeleteLanguageOutput>> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<DeleteLanguageOutput>();
            var validator = new DeleteLanguageCommandHandlerValidator(_languageReadRepository);
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
                var language = await _languageReadRepository.GetAsync(x => x.Id == request.Id);
                var result = await _languageWriteRepository.DeleteAsync(language);

                response.Id = result.Id;
                response.Data = null;
                response.Success = true;
                response.Message = LanguageMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
