using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Commands.Update
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, BaseCommandResponse<GetAboutOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IAboutWriteRepository _writeAboutRepository;

        public UpdateAboutCommandHandler(IMapper mapper, IAboutWriteRepository writeAboutRepository)
        {
            _mapper = mapper;
            _writeAboutRepository = writeAboutRepository;
        }

        public async Task<BaseCommandResponse<GetAboutOutput>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var response=new BaseCommandResponse<GetAboutOutput>();
            var validator = new UpdateAboutCommandHandlerValidatior();
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
                var aboutMapp = _mapper.Map<About>(request);
                var result = await _writeAboutRepository.UpdateAsync(aboutMapp);
                var resultMapp = _mapper.Map<GetAboutOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = AboutMessages.UpdatedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}