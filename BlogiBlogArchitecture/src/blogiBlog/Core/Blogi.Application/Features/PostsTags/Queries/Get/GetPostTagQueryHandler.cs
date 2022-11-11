namespace Blogi.Application.Features.PostsTags.Queries.Get
{
    public class GetPostTagQueryHandler : IRequestHandler<GetPostTagQuery, BaseCommandResponse<List<int>>>
    {
        private readonly IMapper _mapper;
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostTagsReadRepository _postTagsReadRepository;

        public GetPostTagQueryHandler(
            IMapper mapper,
            IPostReadRepository postReadRepository,
            IPostTagsReadRepository postTagsReadRepository
            )
        {
            _mapper = mapper;
            _postReadRepository = postReadRepository;
            _postTagsReadRepository = postTagsReadRepository;
        }

        public async Task<BaseCommandResponse<List<int>>> Handle(GetPostTagQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<int>>();
            var validator = new GetPostTagQueryHandlerValidatior(_postReadRepository);
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
                var result = await _postTagsReadRepository.GetListAsync(x => x.PostId == request.PostId);                
                response.Data = result.Select(x=>x.TagId).ToList();
                response.Id = request.PostId;
                response.Success = true;
                response.Message = PostTagMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}