using Blogi.Application.Features.Tags.Dtos.GetTagList;

namespace Blogi.Application.Features.Tags.Queries.GetList
{
    public class GetListTagQueryHandler : IRequestHandler<GetListTagQuery, BaseCommandResponse<List<GetTagListOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;

        public GetListTagQueryHandler(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        public async Task<BaseCommandResponse<List<GetTagListOutput>>> Handle(GetListTagQuery request, CancellationToken cancellationToken)
        {
            var response= new BaseCommandResponse<List<GetTagListOutput>>();
            var result = await _tagService.GetListAsync(request.Culture);

            if (!result.Any())
            {
                response.Success = false;
                response.Message = TagMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetTagListOutput>();
            }
            else
            {               
                response.Data = result;
                response.Success = true;
                response.Message = TagMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}