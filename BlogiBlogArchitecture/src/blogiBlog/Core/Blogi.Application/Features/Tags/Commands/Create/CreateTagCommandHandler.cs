using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, BaseCommandResponse<GetTagOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ITagReadRepository _tagReadRepository;
        private readonly ITagWriteRepository _tagWriteRepository;

        public CreateTagCommandHandler(
            IMapper mapper,
            ITagReadRepository tagReadRepository,
            ITagWriteRepository tagWriteRepository
            )
        {
            _mapper = mapper;
            _tagReadRepository = tagReadRepository;
            _tagWriteRepository = tagWriteRepository;
        }

        public async Task<BaseCommandResponse<GetTagOutput>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetTagOutput>();
            var validator = new CreateTagCommandHandlerValidatior(_tagReadRepository);
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
                var tagMapp = _mapper.Map<Tag>(request);
                var result = await _tagWriteRepository.AddAsync(tagMapp);
                var resultMapp = _mapper.Map<GetTagOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = TagMessages.CreatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
