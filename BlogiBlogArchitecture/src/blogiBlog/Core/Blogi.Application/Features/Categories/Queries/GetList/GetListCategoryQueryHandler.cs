using Blogi.Application.Features.Categories.Dtos.Get;
using Blogi.Application.Services.CategoryService;

namespace Blogi.Application.Features.Categories.Queries.GetList
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, BaseCommandResponse<List<GetCategoryOutput>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public GetListCategoryQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<BaseCommandResponse<List<GetCategoryOutput>>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<GetCategoryOutput>>();
            var result = await _categoryService.GetListAsync();

            if (!result.Any())
            {
                response.Success = false;
                response.Message = CategoryMessages.GetListNotExists;
                response.Errors = null;
                response.Data = null;
            }
            else
            {
                var resultMapp = _mapper.Map<List<GetCategoryOutput>>(result);
                response.Data = resultMapp;
                response.Success = true;
                response.Message = CategoryMessages.GetListExists;
                response.Errors = null;
            }
            return response;
        }
    }
}
