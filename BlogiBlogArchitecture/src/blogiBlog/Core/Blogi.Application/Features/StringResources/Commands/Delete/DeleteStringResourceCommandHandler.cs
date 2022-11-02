using Blogi.Application.Features.StringResources.Dtos.Delete;

namespace Blogi.Application.Features.StringResources.Commands.Delete
{
    public class DeleteStringResourceCommandHandler : IRequestHandler<DeleteStringResourceCommand, BaseCommandResponse<DeleteStringResourceOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceReadRepository _stringResourceReadRepository;
        private readonly IStringResourceWriteRepository _stringResourceWriteRepository;

        public DeleteStringResourceCommandHandler(
            IMapper mapper,
            IStringResourceReadRepository stringResourceReadRepository, 
            IStringResourceWriteRepository stringResourceWriteRepository
            )
        {
            _mapper = mapper;
            _stringResourceReadRepository = stringResourceReadRepository;
            _stringResourceWriteRepository = stringResourceWriteRepository;
        }

        public async Task<BaseCommandResponse<DeleteStringResourceOutput>> Handle(DeleteStringResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<DeleteStringResourceOutput>();
            var validator = new DeleteStringResourceCommandHandlerValidatior(_stringResourceReadRepository);
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
                var stringResourceMapp =_mapper.Map<StringResource>(request);
                var result = await _stringResourceWriteRepository.DeleteAsync(stringResourceMapp);

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