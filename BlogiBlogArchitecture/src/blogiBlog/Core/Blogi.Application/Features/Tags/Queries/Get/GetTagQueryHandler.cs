using Blogi.Application.Features.Tags.Dtos.Get;

namespace Blogi.Application.Features.Tags.Queries.Get
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, BaseCommandResponse<GetTagOutput>>
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly ITagReadRepository _tagReadRepository;

        public GetTagQueryHandler(IMapper mapper, ITagService tagService, ITagReadRepository tagReadRepository)
        {
            _mapper = mapper;
            _tagService = tagService;
            _tagReadRepository = tagReadRepository;
        }

        public async Task<BaseCommandResponse<GetTagOutput>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<GetTagOutput>();
            var validator = new GetTagQueryHandlerValidatior(_tagReadRepository);
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
                var result = await _tagService.GetAsync(request.Id);
                var resultMapp = _mapper.Map<GetTagOutput>(result);

                response.Id = resultMapp.Id;
                response.Data = resultMapp;
                response.Success = true;
                response.Message = TagMessages.GetByIdExists;
                response.Errors = null;
            }
            return response;
        }
    }
}