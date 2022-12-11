using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Commands.Update
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, BaseCommandResponse<GetTagOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ITagReadRepository _tagReadRepository;
        private readonly ITagWriteRepository _tagWriteRepository;

        public UpdateTagCommandHandler(
            IMapper mapper,
            ITagReadRepository tagReadRepository,
            ITagWriteRepository tagWriteRepository
            )
        {
            _mapper = mapper;
            _tagReadRepository = tagReadRepository;
            _tagWriteRepository = tagWriteRepository;
        }
        public async Task<BaseCommandResponse<GetTagOutput>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetTagOutput>();
            var validator = new UpdateTagCommandHandlerValidatior(_tagReadRepository);
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
                request.Slug = request.Slug.FriendlyUrl();
                var tagMapp = _mapper.Map<Tag>(request);
                var result = await _tagWriteRepository.UpdateAsync(tagMapp);
                var resultMapp = _mapper.Map<GetTagOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = TagMessages.UpdatedSuccess;
                response.Errors = null;
            }
            return response;
        }
    }
}
