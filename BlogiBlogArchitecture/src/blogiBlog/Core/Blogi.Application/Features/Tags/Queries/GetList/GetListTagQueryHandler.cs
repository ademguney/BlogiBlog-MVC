using Blogi.Application.Features.Tags.Dtos.Get;


namespace Blogi.Application.Features.Tags.Queries.GetList
{
    public class GetListTagQueryHandler : IRequestHandler<GetListTagQuery, BaseCommandResponse<List<GetTagOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;

        public GetListTagQueryHandler(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        public async Task<BaseCommandResponse<List<GetTagOutput>>> Handle(GetListTagQuery request, CancellationToken cancellationToken)
        {
            var response= new BaseCommandResponse<List<GetTagOutput>>();
            var result = await _tagService.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = TagMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetTagOutput>();
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetTagOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = TagMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
