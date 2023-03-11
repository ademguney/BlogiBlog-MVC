namespace Blogi.Application.Features.Categories.Queries.GetCategoryCount
{
    public class GetCategoryCountQueryHandler : IRequestHandler<GetCategoryCountQuery, BaseCommandResponse<int>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoryCountQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<BaseCommandResponse<int>> Handle(GetCategoryCountQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var result = await _categoryReadRepository.CountAsync();
            
            response.Data = result;
            response.Success = true;
            response.Errors = null;

            return response;
        }
    }
}