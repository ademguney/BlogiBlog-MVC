using Blogi.Application.Features.StringResources.Dtos.Create;

namespace Blogi.Application.Features.StringResources.Commands.Create
{
    public class CreateStringResourceCommandHandler : IRequestHandler<CreateStringResourceCommand, BaseCommandResponse<CreateStringResourceOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceWriteRepository _stringResourceWriteRepository;

        public CreateStringResourceCommandHandler(IMapper mapper, IStringResourceWriteRepository stringResourceWriteRepository)
        {
            _mapper = mapper;
            _stringResourceWriteRepository = stringResourceWriteRepository;
        }

        public async Task<BaseCommandResponse<CreateStringResourceOutput>> Handle(CreateStringResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<CreateStringResourceOutput>();
            var validator = new CreateStringResourceCommandHandlerValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            else
            {
                var stringResourceMapp = _mapper.Map<StringResource>(request);
                var result = await _stringResourceWriteRepository.AddAsync(stringResourceMapp);
                var resultMapp = _mapper.Map<CreateStringResourceOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StringResourceMessages.CreatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
