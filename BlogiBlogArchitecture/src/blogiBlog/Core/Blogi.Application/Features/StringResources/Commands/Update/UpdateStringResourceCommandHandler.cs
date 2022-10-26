using Blogi.Application.Features.StringResources.Dtos.Update;

namespace Blogi.Application.Features.StringResources.Commands.Update
{
    public class UpdateStringResourceCommandHandler : IRequestHandler<UpdateStringResourceCommand, BaseCommandResponse<UpdateStringResourceOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IStringResourceWriteRepository _stringResourceWriteRepository;

        public UpdateStringResourceCommandHandler(IMapper mapper, IStringResourceWriteRepository stringResourceWriteRepository)
        {
            _mapper = mapper;
            _stringResourceWriteRepository = stringResourceWriteRepository;
        }

        public async Task<BaseCommandResponse<UpdateStringResourceOutput>> Handle(UpdateStringResourceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<UpdateStringResourceOutput>();
            var validator = new UpdateStringResourceCommandHandlerValidator();
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

                var stringResourceMapp = _mapper.Map<StringResource>(request);
                var result = await _stringResourceWriteRepository.UpdateAsync(stringResourceMapp);
                var resultMapp = _mapper.Map<UpdateStringResourceOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = StringResourceMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
