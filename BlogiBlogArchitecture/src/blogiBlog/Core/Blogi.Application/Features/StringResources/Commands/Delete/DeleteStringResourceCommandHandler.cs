using Blogi.Application.Features.StringResources.Dtos.Delete;

namespace Blogi.Application.Features.StringResources.Commands.Delete
{
    public class DeleteStringResourceCommandHandler : IRequestHandler<DeleteStringResourceCommand, BaseCommandResponse<DeleteStringResourceOutput>>
    {
        
        private readonly IStringResourceReadRepository _stringResourceReadRepository;
        private readonly IStringResourceWriteRepository _stringResourceWriteRepository;

        public DeleteStringResourceCommandHandler(IStringResourceReadRepository stringResourceReadRepository, IStringResourceWriteRepository stringResourceWriteRepository)
        {
            _stringResourceReadRepository = stringResourceReadRepository;
            _stringResourceWriteRepository = stringResourceWriteRepository;
        }

        public async Task<BaseCommandResponse<DeleteStringResourceOutput>> Handle(DeleteStringResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<DeleteStringResourceOutput>();
            var validator = new DeleteStringResourceCommandHandlerValidator(_stringResourceReadRepository);
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
                var language = await _stringResourceReadRepository.GetAsync(x => x.Id == request.Id);
                var result = await _stringResourceWriteRepository.DeleteAsync(language);

                response.Id = result.Id;
                response.Data = null;
                response.Success = true;
                response.Message = StringResourceMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
