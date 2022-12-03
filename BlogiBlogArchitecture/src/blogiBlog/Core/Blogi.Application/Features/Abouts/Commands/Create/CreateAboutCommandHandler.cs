using Blogi.Application.Features.Abouts.Dtos.Get;

namespace Blogi.Application.Features.Abouts.Commands.Create
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, BaseCommandResponse<GetAboutOutput>>
    {
        private readonly IMapper _mapper;
        private readonly IAboutReadRepository _aboutReadRepository;
        private readonly IAboutWriteRepository _writeAboutRepository;

        public CreateAboutCommandHandler(IMapper mapper, IAboutWriteRepository writeAboutRepository, IAboutReadRepository aboutReadRepository)
        {
            _mapper = mapper;
            _aboutReadRepository = aboutReadRepository;
            _writeAboutRepository = writeAboutRepository;
        }

        public async Task<BaseCommandResponse<GetAboutOutput>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetAboutOutput>();
            var validator = new CreateAboutCommandHandlerValidatior(_aboutReadRepository);
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
                response.Message = AboutMessages.CreatedSuccess;
                response.Errors = null;
            }

            return response;
        }
    }
}