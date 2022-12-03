namespace Blogi.Application.Features.Abouts.Commands.Delete
{
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAboutReadRepository _aboutReadRepository;
        private readonly IAboutWriteRepository _aboutWriteRepository;
        public DeleteAboutCommandHandler(IMapper mapper, IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository)
        {
            _mapper = mapper;
            _aboutReadRepository = aboutReadRepository;
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new DeleteAboutCommandHandlerValidatior(_aboutReadRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                response.Data = 0;
                response.Success = false;
                response.Message = null;
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var aboutMapp = _mapper.Map<About>(request);
                var result = await _aboutWriteRepository.DeleteAsync(aboutMapp);

                response.Id = result.Id;
                response.Data = result.Id;
                response.Success = true;
                response.Message = ContactMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}