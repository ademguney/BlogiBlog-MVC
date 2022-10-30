using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Delete
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, BaseCommandResponse<GetTagOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ITagReadRepository _tagReadRepository;
        private readonly ITagWriteRepository _tagWriteRepository;

        public DeleteTagCommandHandler(
            IMapper mapper, 
            ITagReadRepository tagReadRepository, 
            ITagWriteRepository tagWriteRepository
            )
        {
            _mapper = mapper;
            _tagReadRepository = tagReadRepository;
            _tagWriteRepository = tagWriteRepository;
        }

        public async Task<BaseCommandResponse<GetTagOutput>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetTagOutput>();
            var validator = new DeleteTagCommandHandlerValidatior(_tagReadRepository);
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
                var tagMapp = _mapper.Map<Tag>(request);
                var result = await _tagWriteRepository.DeleteAsync(tagMapp);

                response.Id = result.Id;
                response.Data = null;
                response.Success = true;
                response.Message = TagMessages.DeletedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
