namespace Blogi.Application.Features.Tags.Queries.GetTagCount
{
    public class GetTagCountQueryHandler : IRequestHandler<GetTagCountQuery, BaseCommandResponse<int>>
    {
        private readonly ITagReadRepository _tagReadRepository;

        public GetTagCountQueryHandler(ITagReadRepository tagReadRepository)
        {
            _tagReadRepository = tagReadRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(GetTagCountQuery request, CancellationToken cancellationToken)
        {
            var response= new BaseCommandResponse<int>();
            var result = await _tagReadRepository.CountAsync();

            response.Data = result;
            response.Success = true;
            response.Errors = null;

            return response;
        }
    }
}