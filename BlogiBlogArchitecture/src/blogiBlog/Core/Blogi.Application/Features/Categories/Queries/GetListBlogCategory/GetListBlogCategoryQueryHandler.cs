using Blogi.Application.Features.Posts.Dtos.GetListBlogPost;

namespace Blogi.Application.Features.Categories.Queries.GetListBlogCategory
{
    public class GetListBlogCategoryQueryHandler : IRequestHandler<GetListBlogCategoryQuery, BaseCommandResponse<List<GetListBlogPostOutput>>>
    {
        private readonly ICategoryService _categoryService;

        public GetListBlogCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<BaseCommandResponse<List<GetListBlogPostOutput>>> Handle(GetListBlogCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetListBlogPostOutput>>();
            var result = await _categoryService.GetListBlogCategoryAsync(request.Id);
            if (!result.Any())
            {
                response.Success = false;
                response.Message = PostMessages.GetListNotExists;
                response.Errors = null;
                response.Data = new List<GetListBlogPostOutput>();
            }
            else
            {
                
                response.Data = result;
                response.Success = true;
                response.Message = PostMessages.GetListExists;
                response.Errors = null;
            }
            return response; ;
        }
    }
}
