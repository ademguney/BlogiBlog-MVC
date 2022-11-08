using Blogi.Application.Features.Post.Dtos.GetList;

namespace Blogi.Application.Features.Post.Queries.GetList
{
    public class GetListPostQueryHandler : IRequestHandler<GetListPostQuery, BaseCommandResponse<List<GetListPostOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public GetListPostQueryHandler(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        public async Task<BaseCommandResponse<List<GetListPostOutput>>> Handle(GetListPostQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListPostOutput>>();
            var result = await _postService.GetListAsync();
            if (!result.Any())
            {
                response.Success = false;
                response.Message = PostMessages.GetListNotExists;
                response.Errors = null;
                response.Data = null;
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetListPostOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = PostMessages.GetListExists;
                response.Errors = null;
            }
            return response;

        }
    }
}
